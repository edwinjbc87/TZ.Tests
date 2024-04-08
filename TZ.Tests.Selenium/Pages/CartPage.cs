using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Tests.Selenium.Pages
{
    public class CartPage: BasePage
    {
        public CartPage(IWebDriver driver): base(driver) { }

        public void Checkout() => driver.FindElement(By.XPath("//button[@data-test='checkout']")).Click();

        public IWebElement GetProduct(string name)
        {
            return driver.FindElements(By.XPath($"//div[@data-test='inventory-item-name'][text()='{name}']"))?.FirstOrDefault();
        }

        public IWebElement GetProductRemoveButton(string productName)
        {
            var removeFromCartDataTest = $"remove-{productName.ToLower().Replace(" ", "-")}";
            return driver.FindElements(By.XPath($"//button[@data-test='{removeFromCartDataTest}']"))?.FirstOrDefault();
        }

        public double GetAddedProductPrice(string productName)
        {
            var removeFromCartDataTest = $"remove-{productName.ToLower().Replace(" ", "-")}";
            return Convert.ToDouble(driver.FindElement(By.XPath($"//button[@data-test='{removeFromCartDataTest}']/preceding-sibling::div[@data-test='inventory-item-price']")).Text.Replace("$", ""));
        }
    }
}
