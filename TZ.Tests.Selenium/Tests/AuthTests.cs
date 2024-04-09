using FluentAssertions;
using TZ.Tests.Selenium.Data;
using TZ.Tests.Selenium.Pages;

namespace TZ.Tests.Selenium.Tests
{
    public class AuthTests: BaseTests
    {
        private LoginPage loginPage;

        public AuthTests(Type browserDriver):base(browserDriver) { }


        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl($"{baseUrl}/");
            loginPage = new LoginPage(driver);
        }

        [Test(Description = "Successful Login")]
        [TestCase(Constants.ValidUser, Constants.ValidPassword)]
        public void WhenValidCredentials_ShowGoToInventory(string username, string password)
        {
            //Act
            loginPage.UsernameInput.SendKeys(username);
            loginPage.PasswordInput.SendKeys(password);
            loginPage.LoginButton.Click();

            //Assert
            loginPage.ErrorMessage.Should().BeNull();
            driver.Url.Should().Contain("/inventory.html");
        }

        [Test(Description = "Failed Login")]
        [TestCase(Constants.InvalidUser, Constants.InvalidPassword)]
        [TestCase(Constants.ValidUser, Constants.InvalidPassword)]
        [TestCase(Constants.InvalidUser, Constants.ValidPassword)]
        public void WhenInvalidCredentials_ShouldShowErrorMessage(string username, string password)
        {
            //Act
            loginPage.UsernameInput.SendKeys(username);
            loginPage.PasswordInput.SendKeys(password);
            loginPage.LoginButton.Click();

            //Assert
            loginPage.ErrorMessage.Should().NotBeNull();
        }


        [Test(Description = "Logout")]
        public void WhenLogoutIsCalled_ShouldShowLoginForm()
        {
            var productsPage = new ProductsPage(driver);

            loginPage.Login();

            productsPage.OpenMenu();
            productsPage.Logout();

            loginPage.LoginButton.Should().NotBeNull();
        }
    }
}