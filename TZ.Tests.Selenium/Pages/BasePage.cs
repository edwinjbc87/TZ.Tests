﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Tests.Selenium.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Logout() => driver.FindElement(By.XPath("//a[@data-test='logout-sidebar-link']")).Click();
        public void OpenMenu() => driver.FindElement(By.XPath("//img[@data-test='open-menu']/preceding-sibling::button")).Click();
    }
}
