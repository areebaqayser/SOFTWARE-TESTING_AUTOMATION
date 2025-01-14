using Allure.NUnit;
using Allure.NUnit.Attributes;
using Automation.POM.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.POM.Login
{
 //   [AllureNUnit]
    [TestFixture]
    public class LoginTestCase : ExtentReport
    {
        static JObject? Login = basePage.ReadJson("Data.json");
        static JToken? loginWithValidUserValidPass = Login.SelectToken("LoginWithValidUserValidPass");
        static JToken? Invalidlogin = Login.SelectToken("LoginWithInValidUserAndPass");
        static JToken? rememberme = Login.SelectToken("LoginWithCheckbox");


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
       // [AllureStep]
        public void LoginWithValidUserValidPass()
        {
            LoginClass loginpage = new LoginClass();

            string url = loginWithValidUserValidPass.SelectToken("url").Value<string>();
            string username = loginWithValidUserValidPass.SelectToken("username").Value<string>();
            string password = loginWithValidUserValidPass.SelectToken("password").Value<string>();
            string value = loginWithValidUserValidPass.SelectToken("value").Value<string>();
            exParentTest = extentReports.CreateTest("LoginWithValidUserValidPass");
            exChildTest = exParentTest.CreateNode("Login Page");

            loginpage.login(url, username, password);
            string val = basePage.driver.FindElement(LoginClass.displayname).Text;
            Assert.AreEqual(value, val);

        }

        [Test]
        public void LoginWithInValidUserAndPass()
        {
            LoginClass loginpage = new LoginClass();

            string url = Invalidlogin.SelectToken("url").Value<string>();
            string username = Invalidlogin.SelectToken("username").Value<string>();
            string password = Invalidlogin.SelectToken("password").Value<string>();
            string errormsg = Invalidlogin.SelectToken("errormsg").Value<string>();

            exParentTest = extentReports.CreateTest("LoginWithInValidUserAndPass");
            exChildTest = exParentTest.CreateNode("Login Page");

            loginpage.login(url, username, password);
            string val = basePage.driver.FindElement(LoginClass.errormsg).Text;
            Assert.AreEqual(errormsg, val);
        }

        [Test]
        public void Login_With_RememberMe_Checked()
        {
            LoginClass loginpage = new LoginClass();

            string url = rememberme.SelectToken("url").Value<string>();
            string username = rememberme.SelectToken("username").Value<string>();
            string password = rememberme.SelectToken("password").Value<string>();

            exParentTest = extentReports.CreateTest("LoginWithValidUserValidPass");
            exChildTest = exParentTest.CreateNode("Login Page");

            loginpage.checkbox(url, username, password);
            
        }
    }
}
