using Automation.POM.Core;
using Automation.POM.EmployeePage;
using AventStack.ExtentReports;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.POM.Password
{
    [TestFixture]
    public class ChangePasswordTestCase : ExtentReport
    {
        static JObject? changepass = basePage.ReadJson("Data.json");
        static JToken? chgsuccess = changepass.SelectToken("PasswordChangesSuccessfully");
        static JToken? chgfail = changepass.SelectToken("PassChange_with_UnmatchedFields");


        [SetUp]
        public void Setup()
        {
            basePage.seleniumInit();
            string ResultFilePath = @"D:\\Automation\\ExtentReport\\TestExecLog_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".html";
            CreateReport(ResultFilePath);
        }

        [TearDown]
        public void TearDown()
        {
            basePage.driverClose();
            extentReports.Flush();
        }
        [Test]
        public void PasswordChangesSuccessfully()
        {
            ChangePasswordClass chg = new ChangePasswordClass();
            string url = chgsuccess.SelectToken("url").Value<string>();
            string username = chgsuccess.SelectToken("username").Value<string>();
            string password = chgsuccess.SelectToken("password").Value<string>();
            string newpass = chgsuccess.SelectToken("newpass").Value<string>();
            string confirm = chgsuccess.SelectToken("confirm").Value<string>();

            exParentTest = extentReports.CreateTest("PasswordChangesSuccessfully");
            exChildTest = exParentTest.CreateNode("Password change");
            chg.change(url, username, password,newpass, confirm);

        }
        [Test]
        public void PassChange_with_UnmatchedFields()
        {
            ChangePasswordClass chg = new ChangePasswordClass();
            string url = chgfail.SelectToken("url").Value<string>();
            string username = chgfail.SelectToken("username").Value<string>();
            string password = chgfail.SelectToken("password").Value<string>();
            string newpass = chgfail.SelectToken("newpass").Value<string>();
            string confirm = chgfail.SelectToken("confirm").Value<string>();


            exParentTest = extentReports.CreateTest("PassChange_with_UnmatchedFields");
            exChildTest = exParentTest.CreateNode("Password change");

            chg.change(url, username, password, newpass, confirm);

        }
    }
}
