

using FluentAssertions;
using OpenQA.Selenium;
using TZ.Tests.Selenium.Data;
using TZ.Tests.Selenium.Pages;

namespace TZ.Tests.Selenium.Tests
{
    public partial class PurchaseTests
    {

        [Test(Description = "Happy Path Workflow. Add Product")]
        [TestCase(Constants.Product1)]
        [TestCase(Constants.Product2)]
        public void WhenAProductIsAdded_ShouldShowInCart(string productName)
        {
            // Act
            loginPage.Login();
            productsPage.AddToCart(productName);
            productsPage.GoToCart();

            //Assert
            cartPage.GetProduct(productName).Should().NotBeNull();
        }

        [Test(Description = "HHappy Path Workflow. Checkout")]
        public void WhenABuyIsCompleted_ShowShowSuccesfulMessage()
        {
            //Act
            loginPage.Login();
            productsPage.AddToCart(Constants.Product1);
            productsPage.GoToCart();
            cartPage.Checkout();
            checkoutPage.FirstNameInput.SendKeys(Faker.Name.First());
            checkoutPage.LastNameInput.SendKeys(Faker.Name.Last());
            checkoutPage.ZipCodeInput.SendKeys(Faker.RandomNumber.Next(10000).ToString());
            checkoutPage.Continue();
            checkoutPage.Finish();

            //Assert
            checkoutPage.PurchaseMessage.Should().Contain(Constants.SuccessPurchaseMessage);
        }
    }
}
