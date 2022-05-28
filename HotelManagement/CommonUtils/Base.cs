using OpenQA.Selenium;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HotelManagement.CommonUtils
{
    public class Base
    {
        /// <summary>
        /// This method is used to log the errors/exceptions during automation
        /// Please check the debug folder for the logs
        /// </summary>
        /// <param name="message"></param>
        public static void LogMessage(string message)
        {
            try
            {
                string logFolder = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory), "Logs");
                if (!Directory.Exists(logFolder))
                    Directory.CreateDirectory(logFolder);
                string logFile = logFolder + "\\Log_" + DateTime.Today.ToString("dd-MM-yy", CultureInfo.CurrentCulture) + ".txt";
                if(!File.Exists(logFile))
                {
                    File.Create(logFile).Dispose();
                    Thread.Sleep(1000);
                }

                using (StreamWriter writer = File.AppendText(logFile))
                {
                    writer.WriteLine("Log Entry: {0}", DateTime.Now.ToString(CultureInfo.InvariantCulture));
                    StackTrace trace = new StackTrace(true);
                    writer.WriteLine("Method Name: " + trace.GetFrame(1).GetMethod().Name);
                    writer.WriteLine("LineNumber: " + trace.GetFrame(1).GetFileLineNumber());
                    writer.WriteLine("Message: " + message);
                    writer.WriteLine("---------------------------------------------------");
                    writer.Flush();
                    writer.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal static bool IsElementPresent(IWebElement ele)
        {
            bool IsVisible = false;
            try
            {
                if (ele.Displayed)
                    IsVisible= true;
            }
            catch (NoSuchElementException ex)
            {
                IsVisible = false;
                LogMessage(ex.Message);
            }
            

            return IsVisible;
        }

        internal static void ScrollDownPage(IWebElement ele)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)DriverContext.Driver;
            js.ExecuteScript("arguments[0].scrollIntoView()", ele);
        }
    }
}
