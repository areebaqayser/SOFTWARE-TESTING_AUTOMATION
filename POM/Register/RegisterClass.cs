using Automation.POM.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;

namespace Automation.POM.Register
{
    public class RegisterClass : basePage
    {
        basePage reg = new basePage();

        #region Locators
        public static By registerlink = By.Id("registerLink");
        public static By Txtusername = By.Id("UserName");
        public static By Txtpassword = By.Id("Password");
        public static By Txtconfirm = By.Id("ConfirmPassword");
        public static By Txtemail = By.Id("Email");
        public static By registerbtn = By.CssSelector("body > div.container.body-content > form > div:nth-child(9) > div > input");
        #endregion

        #region Methods
        public void register(string url, string username, string password, string confirm, string email)
        {
            driver.Url = url;
            TakeScreenshot(Status.Pass, "Enter URL");
            driver.Manage().Window.Maximize();
            driver.FindElement(registerlink).Click();
            TakeScreenshot(Status.Pass, "Click on Register");
            Thread.Sleep(1000);
            driver.FindElement(Txtusername).SendKeys(username);
            TakeScreenshot(Status.Pass, "Enter username");
            driver.FindElement(Txtpassword).SendKeys(password);
            TakeScreenshot(Status.Pass, "Enter password");
            driver.FindElement(Txtconfirm).SendKeys(confirm);
            TakeScreenshot(Status.Pass, "Re-Enter password");
            driver.FindElement(Txtemail).SendKeys(email);
           TakeScreenshot(Status.Pass, "Enter email");
            Thread.Sleep(1000);
            driver.FindElement(registerbtn).Submit();
            TakeScreenshot(Status.Pass, "Click on register");

        }
        #endregion
    }
}
