using Automation.POM.Core;
using Automation.POM.Login;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.POM.Register
{
    [TestFixture]
    public class RegisterTestCases : ExtentReport
    {
        static JObject? Register = basePage.ReadJson("Data.json");
        static JToken? registersuccess = Register.SelectToken("RegisterWithValidData");
        static JToken? registerfail = Register.SelectToken("RegisterLeavingFieldsEmpty");


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
        public void RegisterWithValidData()
        {
            RegisterClass reg = new RegisterClass();

            string url = registersuccess.SelectToken("url").Value<string>();
            string username = registersuccess.SelectToken("username").Value<string>();
            string password = registersuccess.SelectToken("password").Value<string>();
            string confirm = registersuccess.SelectToken("confirm").Value<string>();
            string email = registersuccess.SelectToken("email").Value<string>();

            exParentTest = extentReports.CreateTest("RegisterWithValidData");
            exChildTest = exParentTest.CreateNode("Register Page");

            reg.register(url, username, password,confirm,email );      

        }

        [Test]
        public void RegisterLeavingFieldsEmpty()
        {
            RegisterClass reg = new RegisterClass();

            string url = registerfail.SelectToken("url").Value<string>();
            string username = registerfail.SelectToken("username").Value<string>();
            string password = registerfail.SelectToken("password").Value<string>();
            string confirm = registerfail.SelectToken("confirm").Value<string>();
            string email = registerfail.SelectToken("email").Value<string>();
            exParentTest = extentReports.CreateTest("RegisterLeavingFieldsEmpty");
            exChildTest = exParentTest.CreateNode("Register Page");
            reg.register(url, username, password, confirm, email);

        }
    }
}
