using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;

namespace Automation.POM.Core
{
    public class basePage
    {
        public static IWebDriver driver;
        public static JObject? jObject { get; set; }
        public static JObject? appConfig { get; set; }
        public static string? BaseURL { get; set; }
        public static string? bearerToken { get; set; }
        public static string? APIBaseURL { get; set; }



        public static void seleniumInit()
        {
            var mydriver = new ChromeDriver();

            driver = mydriver;

        }
        public static void driverClose()
        {
            driver.Close();
        }
        /*public static void driverQuit()
        {
            driver.Quit();
        }*/


        public static void TakeScreenshot(Status status, string stepDetail)
        {
            string path = @"D:\\Automation\\ExtentReport\\images\\" + DateTime.Now.ToString("yyyyMMddHHmmss") + " .png";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            File.WriteAllBytes(path, screenshot.AsByteArray);
            ExtentReport.exChildTest.Log(status, stepDetail, MediaEntityBuilder
                .CreateScreenCaptureFromPath(path).Build());
        }
        public static JObject ReadJson(string filename)
        {
            string myJsonString = File.ReadAllText(@"D:\\Automation\\TestData\\" + filename);
            var myJObject = JObject.Parse(myJsonString);
            return myJObject;
        }
    }
}
