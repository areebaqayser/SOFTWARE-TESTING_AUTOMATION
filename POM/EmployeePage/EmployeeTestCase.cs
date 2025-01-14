using Automation.POM.Core;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.POM.EmployeePage
{
    [TestFixture]
    internal class EmployeeTestCase : ExtentReport
    {
        static JObject? searching = basePage.ReadJson("Data.json");
        static JToken? searchemp = searching.SelectToken("SearchEmployeeSuccess");

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
        public void SearchEmployeeSuccess()
        {
            EmployeeClass emp = new EmployeeClass();
            string url = searchemp.SelectToken("url").Value<string>();
            string search = searchemp.SelectToken("search").Value<string>();
            string find = searchemp.SelectToken("find").Value<string>();

            exParentTest = extentReports.CreateTest("SearchEmployeeSuccess");
            exChildTest = exParentTest.CreateNode("Employee Page");

            emp.search(url, search);

        }


    }
}
