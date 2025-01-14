using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.POM.Core
{
    public class ExtentReport
    {
        public static ExtentReports extentReports;
        public static ExtentTest exParentTest;
        public static ExtentTest exChildTest;
        public static string dirpath;

        // Generate Extent Report
        public static void CreateReport(string dirpath)
        {
            extentReports = new ExtentReports();

            var sparkReporter = new ExtentSparkReporter(@dirpath);
            extentReports.AttachReporter(sparkReporter);
        }
    }
}
