using Automation.POM.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;

namespace Automation.POM.Password
{
    internal class ChangePasswordClass : basePage
    {
        basePage changepass = new basePage();

        #region Locators
        public static By loginlink = By.Id("loginLink");
        public static By usernameTxt = By.Id("UserName");
        public static By passwordTxt = By.Id("Password");
        public static By loginBtn = By.ClassName("btn");
        public static By displayname = By.CssSelector("#logoutForm > ul > li:nth-child(1) > a");
        public static By changebtn = By.CssSelector("body > div.container.body-content > div > dl > dd:nth-child(2) > a");
        public static By errormsg1 = By.CssSelector("body > div.container.body-content > form > div.text-danger.validation-summary-errors > ul > li");
        public static By current = By.Id("OldPassword");
        public static By newpass = By.Id("NewPassword");
        public static By confirmpass = By.Id("ConfirmPassword");
        public static By btn = By.CssSelector("body > div.container.body-content > form > div:nth-child(8) > div > input");
        //  public static By req2 = By.CssSelector("#loginForm > form > div:nth-child(4) > div > span > span");

        #endregion

        #region Methods
        public void change(string url, string username, string password, string newpassword, string confirm)
        {
            driver.Url = url;
            TakeScreenshot(Status.Pass, "Enter URL");
            driver.Manage().Window.Maximize();
            driver.FindElement(loginlink).Click();
            Thread.Sleep(1000);
            TakeScreenshot(Status.Pass, "Click login");
            driver.FindElement(usernameTxt).SendKeys(username);
           TakeScreenshot(Status.Pass, "Enter username");
            driver.FindElement(passwordTxt).SendKeys(password);
            TakeScreenshot(Status.Pass, "Enter password");
            driver.FindElement(loginBtn).Submit();
            TakeScreenshot(Status.Pass, "Click login");
            driver.FindElement(displayname).Click();
            TakeScreenshot(Status.Pass, "click on name");
            Thread.Sleep(1000);
            driver.FindElement(changebtn).Click();
            TakeScreenshot(Status.Pass, "Click changepassword");
            driver.FindElement(current).SendKeys(password);
            TakeScreenshot(Status.Pass, "Enter current pass");
            driver.FindElement(newpass).SendKeys(newpassword);
            TakeScreenshot(Status.Pass, "Enter new password");
            driver.FindElement(confirmpass).SendKeys(confirm);
            TakeScreenshot(Status.Pass, "Re-Enter newpass");
            Thread.Sleep(1000);
            driver.FindElement(btn).Click();
           TakeScreenshot(Status.Pass, "Click on change password button");

        }
        #endregion
    }
}
