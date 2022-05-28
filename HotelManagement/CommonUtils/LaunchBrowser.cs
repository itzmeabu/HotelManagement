using HotelManagement.CommonUtils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement
{
    /// <summary>
    /// This class must be used as base class for all test fixture classes
    /// </summary>
    [TestFixture]
    public class LaunchBrowser
    {
        public enum BrowserType
        {
            Chrome,
            Edge
        }


        private string Url = ConfigReader.GetUrl();

        public void OpenBrowser(BrowserType _browserType)
        {
            switch (_browserType)
            {
                case BrowserType.Chrome:
                    DriverContext.Driver = new ChromeDriver();
                    
                    //
                    break;
                case BrowserType.Edge:
                    // we can set another browser driver here
                    // To Do
                    break;

                default:
                    DriverContext.Driver = new ChromeDriver();
                    break;
            }

            DriverContext.Driver.Manage().Window.Maximize();
            DriverContext.Driver.Navigate().GoToUrl(Url);
            DriverContext.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100);
        }

        /// <summary>
        /// This method is to take the screen shots when test case failed during execution
        /// Please find the screen shots under debug folder of this project
        /// </summary>
        public void TakeScreenShotForFailureTest()
        {
            try
            {
                if(TestContext.CurrentContext.Result.Outcome.Status.Equals(NUnit.Framework.Interfaces.TestStatus.Failed))
                {
                    string filePath = "TestCaseFailed" + DateTime.Now.ToString("dd-MMMMM-yyyy hh-mm", CultureInfo.CurrentCulture);
                    string screenShotsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ScreenShots\\", filePath);
                    if(!Directory.Exists(screenShotsFolder))
                    {
                        Directory.CreateDirectory(screenShotsFolder);
                    }
                    string textFixtureNameSpace = TestContext.CurrentContext.Test.ClassName.ToString();
                    string[] textFixtureDetails = textFixtureNameSpace.Split('.');
                    string testCaseFixtureName = textFixtureDetails[textFixtureDetails.Length-1];
                    string testCaseName = TestContext.CurrentContext.Test.Name.ToString();
                    string subFolderPath = Path.Combine(screenShotsFolder, testCaseFixtureName);
                    if (!Directory.Exists(subFolderPath))
                        Directory.CreateDirectory(subFolderPath);
                    string screenShotName = subFolderPath + "\\" + testCaseName + ".jpeg";
                    ((ITakesScreenshot)DriverContext.Driver).GetScreenshot().SaveAsFile(screenShotName, ScreenshotImageFormat.Jpeg);
                }
            }
            catch (Exception ex)
            {

                Base.LogMessage(ex.Message);
            }
        }

        [TearDown]
        public void TearDown()
        {
            TakeScreenShotForFailureTest();
        }

        [OneTimeTearDown]
        public void Close()
        {
            DriverContext.Driver.Quit();
        }
    }
}
