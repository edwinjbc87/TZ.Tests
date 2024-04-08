using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZ.Tests.Selenium.Data
{
    public class Constants
    {
        public const string BaseUrl = "https://www.saucedemo.com";

        public const string ValidUser = "standard_user";
        public const string ValidPassword = "secret_sauce";
        public const string InvalidUser = "locked_out_user";
        public const string InvalidPassword = "wrong_password";

        public const string Product1 = "Sauce Labs Bike Light";
        public const string Product2 = "Sauce Labs Fleece Jacket";
        public const string Product3 = "Sauce Labs Onesie";

        public const string SuccessPurchaseMessage = "Thank you for your order!";

        public const string OrderByPrice_LowToHigh = "Price (low to high)";
    }
}
