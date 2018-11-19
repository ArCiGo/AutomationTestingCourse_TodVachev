using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumScreenshot
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            IWebDriver chrome = new ChromeDriver();
            string screenshotsDirectory = Directory.GetCurrentDirectory() + @"\screenshots";

            chrome.Navigate().GoToUrl("https://www.google.com.mx/");

            Screenshot googleScreenshot = ((ITakesScreenshot)chrome).GetScreenshot();

            if (!Directory.Exists(screenshotsDirectory))
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\screenshots");
            }

            googleScreenshot.SaveAsFile(Directory.GetCurrentDirectory() + @"\screenshots\googlescreenshots.png", ScreenshotImageFormat.Png);

            chrome.Quit();
        }
    }
}
