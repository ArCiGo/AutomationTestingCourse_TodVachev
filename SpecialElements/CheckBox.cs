using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecialElements
{
    class CheckBox
    {
        static void Main(string[] args)
        {
            Setup setup = new Setup();
            Miscellaneous misc = new Miscellaneous();
            IWebElement checkBox;

            string url = "http://testing.todvachev.com/special-elements/check-button-test-3/";
            string option = "1";

            setup.driver.Navigate().GoToUrl(url);

            checkBox = setup.driver.FindElement(By.CssSelector("#post-33 > div > p:nth-child(8) > input[type=\"checkbox\"]:nth-child("+ option +")"));

            //if(checkBox.GetAttribute("checked") == "true")
            //{
            //    misc.GreenMessage("Checkox is checked");
            //}
            //else
            //{
            //    misc.RedMessage("Checkox is not checked");
            //}

            checkBox.Click();

            Thread.Sleep(3000);

            setup.driver.Quit();
            Console.ReadKey();
        }
    }
}
