using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecialElements
{
    class AlertBox
    {
        static void Main(string[] args)
        {
            Setup setup = new Setup();
            Miscellaneous misc = new Miscellaneous();
            IAlert alert;
            IWebElement image;

            string url = "http://testing.todvachev.com/special-elements/alert-box/";

            setup.driver.Navigate().GoToUrl(url);

            alert = setup.driver.SwitchTo().Alert();
            Console.WriteLine(alert.Text);
            alert.Accept();

            image = setup.driver.FindElement(By.CssSelector("#post-119 > div > figure > img"));

            try
            {
                if (image.Displayed)
                {
                    misc.GreenMessage("The alert was successfully accepted and I can see the image");
                }
            }
            catch (NoSuchElementException ex)
            {
                misc.RedMessage("Something went wrong");
                throw;
            }

            Thread.Sleep(3000);

            setup.driver.Quit();
            Console.ReadKey();
        }
    }
}
