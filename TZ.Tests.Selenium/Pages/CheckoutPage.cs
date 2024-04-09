using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TZ.Tests.Selenium.Data;

namespace TZ.Tests.Selenium.Pages
{
    public class CheckoutPage: AuthorizedPage
    {
        public CheckoutPage(IWebDriver driver) : base(driver) { }

        public IWebElement FirstNameInput { 
            get { return driver.FindElement(By.XPath("//input[@data-test='firstName']")); }
        }

        public IWebElement LastNameInput
        {
            get { return driver.FindElement(By.XPath("//input[@data-test='lastName']")); }
        }

        public IWebElement ZipCodeInput
        {
            get { return driver.FindElement(By.XPath("//input[@data-test='postalCode']")); }
        }

        public string PurchaseMessage
        {
            get { return driver.FindElement(By.XPath("//div[@data-test='checkout-complete-container']")).Text; }
        }

        public double ItemTotal
        {
            get { return Convert.ToDouble(driver.FindElement(By.XPath("//div[@data-test='subtotal-label']")).Text.Replace("Item total: $", "")); }
        }

        public void Continue() => driver.FindElement(By.XPath("//input[@data-test='continue']")).Click();
        public void Finish() => driver.FindElement(By.XPath("//button[@data-test='finish']")).Click();
    }
}
