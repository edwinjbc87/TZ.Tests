using OpenQA.Selenium;
using TZ.Tests.Selenium.Data;

namespace TZ.Tests.Selenium.Pages
{
    public class LoginPage: BasePage
    {
        public IWebElement UsernameInput { 
            get { return driver.FindElement(By.XPath("//input[@data-test='username']")); }
        }

        public IWebElement PasswordInput
        {
            get { return driver.FindElement(By.XPath("//input[@data-test='password']")); }
        }

        public IWebElement LoginButton
        {
            get { return driver.FindElement(By.XPath("//input[@data-test='login-button']")); }
        }

        public IWebElement ErrorMessage
        {
            get { return driver.FindElements(By.XPath("//*[@data-test='error']"))?.FirstOrDefault(); }
        }


        public LoginPage(IWebDriver driver): base(driver) { 
        }

        public void Login()
        {
            UsernameInput.SendKeys(Constants.ValidUser);
            PasswordInput.SendKeys(Constants.ValidPassword);
            LoginButton.Click();
        }
    }
}
