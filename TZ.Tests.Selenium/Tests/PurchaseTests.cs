using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Tests.Selenium.Pages;

namespace TZ.Tests.Selenium.Tests
{
    public partial class PurchaseTests: BaseTests
    {
        private LoginPage loginPage;
        private CartPage cartPage;
        private ProductsPage productsPage;
        private CheckoutPage checkoutPage;

        public PurchaseTests(Type type) : base(type)
        {
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl($"{baseUrl}/");

            loginPage = new LoginPage(driver);
            cartPage = new CartPage(driver);
            productsPage = new ProductsPage(driver);
            checkoutPage = new CheckoutPage(driver);

            driver.Manage().Cookies.DeleteAllCookies();
            (driver as IJavaScriptExecutor).ExecuteScript("sessionStorage.clear();");
            (driver as IJavaScriptExecutor).ExecuteScript("localStorage.clear();");
        }

    }
}
