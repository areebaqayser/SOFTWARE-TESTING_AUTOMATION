using Automation.POM.Core;
using Automation.POM.Login;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.POM.Logout
{
    [TestFixture]
    public class LogoutTestcase : ExtentReport
    {

        static JObject? logout = basePage.ReadJson("Data.json");
        static JToken? logoutsuccess = logout.SelectToken("UserlogoutSuccessfully");


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

        public void UserlogoutSuccessfully()
        {
            LogoutClass logoutpage = new LogoutClass();
            LoginClass loginpage = new LoginClass();

            string url = logoutsuccess.SelectToken("url").Value<string>();
            string username = logoutsuccess.SelectToken("username").Value<string>();
            string password = logoutsuccess.SelectToken("password").Value<string>();

            exParentTest = extentReports.CreateTest("UserlogoutSuccessfully");
            exChildTest = exParentTest.CreateNode("Logout Page");
            loginpage.login(url, username, password);
            logoutpage.logoff();
        }
    }
}
