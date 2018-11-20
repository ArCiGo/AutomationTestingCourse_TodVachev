using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCloseTabs
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.google.com.mx");

            Actions actions = new Actions(driver);

            actions.SendKeys(Keys.Control + "t").Build().Perform();

            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open();");

            List<string> handles = driver.WindowHandles.ToList();

            //for (int i = 0; i < handles.Count; i++)
            //{
            //    Console.WriteLine(handles[i]);
            //}

            driver.SwitchTo().Window(handles[3]);
            driver.Navigate().GoToUrl("https://www.google.com/gmail/");

            for (int i = 0; i < handles.Count; i++)
            {
                if (i != 3)
                {
                    driver.SwitchTo().Window(handles[i]);
                    driver.Close();
                }
            }
        }
    }
}
