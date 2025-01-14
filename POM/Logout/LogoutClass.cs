using Automation.POM.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;

namespace Automation.POM.Logout
{
    public class LogoutClass : basePage
    {
        basePage logoutpage = new basePage();

        #region Locators
        public static By logoutlink = By.CssSelector("#logoutForm > ul > li:nth-child(2) > a");

        #endregion

        #region Methods

        public void logoff()
        { 
            Thread.Sleep(1000);
            driver.FindElement(logoutlink).Click();
            TakeScreenshot(Status.Pass, "Click on Logout");
        }

        #endregion

    }
}
