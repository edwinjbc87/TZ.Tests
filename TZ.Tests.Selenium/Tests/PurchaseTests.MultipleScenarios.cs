using FluentAssertions;
using TZ.Tests.Selenium.Data;

namespace TZ.Tests.Selenium.Tests
{
    public partial class PurchaseTests
    {
        [Test(Description = "Multiple Scenarios Workflow. Sort by price(low to high)")]
        public void WhenSortByPriceIsSelected_ShouldSortItemsByPrice()
        {
            // Arrange
            var isSortedByPriceLowToHigh = true;


            // Act
            loginPage.Login();
            productsPage.SelectSortStrategy(Constants.OrderByPrice_LowToHigh);
            var prices = productsPage.GetPricesList();
            isSortedByPriceLowToHigh = IsSortedList<double>(prices);

            //Assert
            productsPage.SelectedProductSortStrategyName.Should().Be(Constants.OrderByPrice_LowToHigh);
            isSortedByPriceLowToHigh.Should().BeTrue();
        }

        [Test(Description = "Multiple Scenarios Workflow. Show remove button for added productss")]
        public void WhenAddProductsToCart_ShouldShowRemoveButton()
        {
            loginPage.Login();
            productsPage.AddToCart(Constants.Product2);
            productsPage.AddToCart(Constants.Product3);

            productsPage.GetProductRemoveButton(Constants.Product2).Should().NotBeNull();
            productsPage.GetProductRemoveButton(Constants.Product3).Should().NotBeNull();
        }

        [Test(Description = "Multiple Scenarios Workflow. Show Products qty in cart")]
        public void WhenAddProductsToCart_ShouldShowProductQtyInCartIcon()
        {
            //Arrange
            var expectedResult = 2;

            //Act
            loginPage.Login();
            productsPage.AddToCart(Constants.Product2);
            productsPage.AddToCart(Constants.Product3);

            //assert
            productsPage.ProductsQtyInCartIcon.Should().Be(expectedResult);
        }

        [Test(Description = "Multiple Scenarios Workflow. Match Products Item Price with Cart Item Price")]
        public void WhenAddProductsToCart_ShouldMatchPriceInProductsAndCartPages()
        {
            //Arrange
            var product1PriceInProductsPage = 0.0;
            var product2PriceInProductsPage = 0.0;
            var product1PriceInCartPage = 0.0;
            var product2PriceInCartPage = 0.0;

            //Act
            loginPage.Login();
            productsPage.AddToCart(Constants.Product2);
            productsPage.AddToCart(Constants.Product3);

            product1PriceInProductsPage = productsPage.GetAddedProductPrice(Constants.Product2);
            product2PriceInProductsPage = productsPage.GetAddedProductPrice(Constants.Product3);

            productsPage.GoToCart();

            product1PriceInCartPage = cartPage.GetAddedProductPrice(Constants.Product2);
            product2PriceInCartPage = cartPage.GetAddedProductPrice(Constants.Product3);

            //Assert
            
            product1PriceInProductsPage.Should().Be(product1PriceInCartPage);
            product2PriceInProductsPage.Should().Be(product2PriceInCartPage);
        }

        [Test(Description = "Multiple Scenarios Workflow. Match Cart Icon qty and products qty in Cart Page")]
        public void WhenRemoveProductFromCart_ShouldMatchQtyInCartPageAndIcon()
        {
            //Arrange
            var productsQtyInCart = 0.0;
            var productsQtyInCartIcon = 0.0;

            //Act
            loginPage.Login();
            productsPage.AddToCart(Constants.Product2);
            productsPage.AddToCart(Constants.Product3);

            productsPage.GoToCart();

            cartPage.RemoveFromCart(Constants.Product3);
            productsQtyInCart = cartPage.ProductsQtyInCart;
            productsQtyInCartIcon = cartPage.ProductsQtyInCartIcon;
            

            //Assert
            productsQtyInCart.Should().Be(productsQtyInCartIcon);
        }

        [Test(Description = "Multiple Scenarios Workflow. Match Products price with Checkout total")]
        public void WhenCheckout_ShouldMatchItemsTotatWithProductPrice()
        {
            //Arrange
            var productPriceInProductsPage = 0.0;
            var checkoutItemTotal = 0.0;

            //Act
            loginPage.Login();
            productsPage.AddToCart(Constants.Product2);
            productsPage.AddToCart(Constants.Product3);
            productPriceInProductsPage = productsPage.GetAddedProductPrice(Constants.Product2);

            productsPage.GoToCart();

            cartPage.RemoveFromCart(Constants.Product3);
            cartPage.Checkout();

            checkoutPage.FirstNameInput.SendKeys(Faker.Name.First());
            checkoutPage.LastNameInput.SendKeys(Faker.Name.Last());
            checkoutPage.ZipCodeInput.SendKeys(Faker.RandomNumber.Next(10000).ToString());
            checkoutPage.Continue();
            checkoutItemTotal = checkoutPage.ItemTotal;


            //Assert
            checkoutItemTotal.Should().Be(productPriceInProductsPage);
        }

        #region Helpers
        private bool IsSortedList<T>(IList<T> list) where T : IComparable<T>
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].CompareTo(list[i - 1]) < 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
