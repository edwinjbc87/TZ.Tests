using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TZ.Tests.Selenium.Data;

namespace TZ.Tests.Selenium.Tests
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(EdgeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    public class BaseTests
    {
        protected readonly string baseUrl;
        private readonly Type browserDriver;

        protected IWebDriver driver;
        public BaseTests(Type browserDriver)
        {
            this.baseUrl = Constants.BaseUrl;
            this.browserDriver = browserDriver;
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = (IWebDriver)Activator.CreateInstance(browserDriver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

    }
}
