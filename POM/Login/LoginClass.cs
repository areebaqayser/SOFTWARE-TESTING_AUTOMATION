using Automation.POM.Core;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.POM.Login
{
    public class LoginClass : basePage
    {
        basePage loginpage = new basePage();

        #region Locators
        public static By loginlink = By.Id("loginLink");
        public static By usernameTxt = By.Id("UserName");
        public static By passwordTxt = By.Id("Password");
        public static By loginBtn = By.ClassName("btn");
        public static By displayname = By.CssSelector("#logoutForm > ul > li:nth-child(1) > a");
        public static By errormsg = By.CssSelector("#loginForm > form > div.validation-summary-errors.text-danger > ul > li");
        public static By chk = By.Id("RememberMe");

        public static By req1 = By.CssSelector("#loginForm > form > div:nth-child(2) > div > span > span");

        #endregion


        #region Method
        public void login(string url, string username, string password)
        {
            driver.Url = url;
            TakeScreenshot(Status.Pass, "Open URL");
            driver.Manage().Window.Maximize();
            driver.FindElement(loginlink).Click();
            TakeScreenshot(Status.Pass, "Click on Login");
            driver.FindElement(usernameTxt).SendKeys(username);
            TakeScreenshot(Status.Pass, "Enter username");
            driver.FindElement(passwordTxt).SendKeys(password);
            TakeScreenshot(Status.Pass, "Enter password");
            driver.FindElement(loginBtn).Submit();
            TakeScreenshot(Status.Pass, "Click on Login button");

        }

        public void checkbox(string url, string username, string password)
        {
            driver.Url = url;
            TakeScreenshot(Status.Pass, "Enter URL");
            driver.Manage().Window.Maximize();
            driver.FindElement(loginlink).Click();
            TakeScreenshot(Status.Pass, "Click on Login");
            driver.FindElement(usernameTxt).SendKeys(username);
             TakeScreenshot(Status.Pass, "Enter username");
            driver.FindElement(passwordTxt).SendKeys(password);
             TakeScreenshot(Status.Pass, "Enter password");
            driver.FindElement(chk).Click();
            TakeScreenshot(Status.Pass, "Check Remember me");
            driver.FindElement(loginBtn).Submit();
            TakeScreenshot(Status.Pass, "Click on Login button");

        }
        #endregion
    }
}
