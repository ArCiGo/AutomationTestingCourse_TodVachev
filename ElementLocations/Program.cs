using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementLocations
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            string url = "http://testing.todvachev.com";

            driver.Navigate().GoToUrl(url);

            IWebElement image = driver.FindElement(By.CssSelector("#page-17 > div > p:nth-child(1) > a > img"));
            IWebElement content = driver.FindElement(By.CssSelector("#page-17 > div"));

            /* Location and size of the element */
            /* driver.Manage().Window.Maximize();  // When the window is maximized, it returns another pair of coordinates. Without this line, it returns the coordinates based on the size of the window

           // Getting the image location
           Console.WriteLine(image.Location.X);
           Console.WriteLine(image.Location.Y);

           // Getting the image size
           Console.WriteLine(image.Size.Height);
           Console.WriteLine(image.Size.Width); */

            SetStyle(driver, content, "color", "green");

            driver.Quit();
        }

        public static void SetStyle(IWebDriver driver, IWebElement element, string style, string styleValue)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            string script = String.Format("arguments[0].style[\"{0}\"] = \"{1}\"", style, styleValue);

            jsExecutor.ExecuteScript(script, element);
        }
    }
}
