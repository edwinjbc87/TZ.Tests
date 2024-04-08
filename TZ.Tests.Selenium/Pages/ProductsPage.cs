using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Tests.Selenium.Pages
{
    public class ProductsPage:BasePage
    {
        public ProductsPage(IWebDriver driver) : base(driver) { }

        public string SelectedProductSortStrategyName
        {
            get { return driver.FindElement(By.XPath("//span[@data-test='active-option']")).Text; }
        }

        public void AddToCart(string productName)
        {
            var addToCartDataTest = $"add-to-cart-{productName.ToLower().Replace(" ", "-")}";
            driver.FindElement(By.XPath($"//button[@data-test='{addToCartDataTest}']")).Click();
        }

        public void GoToCart() => driver.FindElement(By.XPath("//a[@data-test='shopping-cart-link']")).Click();
        
        public void SelectSortStrategy(string orderName)
        {
            driver.FindElement(By.XPath($"//select[@data-test='product-sort-container']//option[text()='{orderName}']")).Click();
        }

        public List<double> GetPricesList()
        {
            return driver.FindElements(By.XPath("//div[@data-test='inventory-item-price']")).Select(elem => Convert.ToDouble(elem.Text.Replace("$", ""))).ToList();
        }

        public IWebElement GetProductRemoveButton(string productName)
        {
            var removeFromCartDataTest = $"remove-{productName.ToLower().Replace(" ", "-")}";
            return driver.FindElements(By.XPath($"//button[@data-test='{removeFromCartDataTest}']"))?.FirstOrDefault();
        }

        public int ProductsQtyInCart
        {
            get { return Convert.ToInt32(driver.FindElements(By.XPath("//span[@data-test='shopping-cart-badge']"))?.FirstOrDefault()?.Text ?? "0"); }
        }

        public double GetAddedProductPrice(string productName)
        {
            var removeFromCartDataTest = $"remove-{productName.ToLower().Replace(" ", "-")}";
            return Convert.ToDouble(driver.FindElement(By.XPath($"//button[@data-test='{removeFromCartDataTest}']/preceding-sibling::div[@data-test='inventory-item-price']")).Text.Replace("$", ""));
        }
    }
}
