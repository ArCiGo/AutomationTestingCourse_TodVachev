using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserlikeActions
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            string url = "http://testing.todvachev.com/draganddrop/draganddrop.html";
            string lightGreen = "rgba(144, 238, 144, 1)";

            driver.Navigate().GoToUrl(url);

            string[] elementIDs =
            {
                "Drag1",
                "Drag2",
                "Drag3",
                "Drag4",
                "Drag5"
            };
            IWebElement[] elements =
            {
                driver.FindElement(By.Id(elementIDs[0])),
                driver.FindElement(By.Id(elementIDs[1])),
                driver.FindElement(By.Id(elementIDs[2])),
                driver.FindElement(By.Id(elementIDs[3])),
                driver.FindElement(By.Id(elementIDs[4]))
            };

            Actions actions = new Actions(driver);

            actions.MoveToElement(elements[0]).Build().Perform();

            Console.WriteLine(elements[0].GetCssValue("background-color") == lightGreen);
            Console.WriteLine(elements[1].GetCssValue("background-color") == lightGreen);
        }
    }
}
