

using FluentAssertions;
using TZ.Tests.Selenium.Data;

namespace TZ.Tests.Selenium.Tests
{
    public partial class PurchaseTests
    {

        [Test(Description = "Happy Path Workflow. Add Product")]
        [TestCase(Constants.Product1)]
        [TestCase(Constants.Product2)]
        [TestCase(Constants.Product3)]
        public void WhenAProductIsAdded_ShouldShowInCartPage(string productName)
        {
            // Act
            loginPage.Login();
            productsPage.AddToCart(productName);
            productsPage.GoToCart();

            //Assert
            cartPage.GetProduct(productName).Should().NotBeNull();
        }

        [Test(Description = "Happy Path Workflow. Checkout")]
        public void WhenPurchaseIsCompleted_ShouldShowSuccesfulMessage()
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
