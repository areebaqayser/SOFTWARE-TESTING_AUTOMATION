using Automation.POM.Core;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;

namespace Automation.POM.EmployeePage
{
    public class EmployeeClass : basePage
    {
        #region Locators
        public static By employeeList = By.CssSelector("body > div.navbar.navbar-inverse.navbar-fixed-top > div > div.navbar-collapse.collapse > ul:nth-child(1) > li:nth-child(3)");
        public static By searchbar = By.Name("searchTerm");
        public static By searchbtn = By.CssSelector("body > div.container.body-content > form > input.btn.btn-default");
        public static By benefitlink = By.CssSelector("body > div.container.body-content > table > tbody > tr:nth-child(2) > td:nth-child(6) > a:nth-child(1)");

        #endregion

        #region Methods

        public void search(string url, string name)
        {
            driver.Url = url;
            TakeScreenshot(Status.Pass, "open URL");
            driver.Manage().Window.Maximize();
            driver.FindElement(employeeList).Click();
            TakeScreenshot(Status.Pass, "click on employee list");
            Thread.Sleep(1000);
            driver.FindElement(searchbar).SendKeys(name);
            TakeScreenshot(Status.Pass, "Type employee name");
            Thread.Sleep(1000);
            driver.FindElement(searchbtn).Submit();
            TakeScreenshot(Status.Pass, "Click search");

            driver.FindElement(benefitlink).Click();

            TakeScreenshot(Status.Pass, "Click benefits");
            Thread.Sleep(1000);
        }     
        #endregion
    }

}
