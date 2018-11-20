using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsAndTabs
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> handles = new List<string>();

            IWebDriver driver = new ChromeDriver();
            IWebElement newTab;
            IWebElement newWindow;

            string url = "http://testing.todvachev.com/tabs-and-windows/new-tab/";
            string newTabSelector = "#post-182 > div > p:nth-child(1) > a:nth-child(1)";
            string newWindowSelector = "#post-182 > div > p:nth-child(1) > a:nth-child(3)";

            driver.Navigate().GoToUrl(url);

            newTab = driver.FindElement(By.CssSelector(newTabSelector));
            newWindow = driver.FindElement(By.CssSelector(newWindowSelector));

            newTab.Click();

            handles = driver.WindowHandles.ToList();

            // Retrieves the window handles
            //for (int i = 0; i < handles.Count; i++)
            //{
            //    Console.WriteLine(handles[i]);
            //}

            IWebElement usernameBox = driver.FindElement(By.Name("username"));
            usernameBox.SendKeys("selenium");

            driver.SwitchTo().Window(handles[2]);

            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium");
        }
    }
}
