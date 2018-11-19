using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace SpecialElements
{
    class RadioButton
    {
        static void Main(string[] args)
        {
            Setup setup = new Setup();
            Miscellaneous misc = new Miscellaneous();
            IWebElement radioButton;

            string url = "http://testing.todvachev.com/special-elements/radio-button-test/";
            string[] option = {"1", "3", "5"};

            setup.driver.Navigate().GoToUrl(url);

            for (int i = 0; i < option.Length; i++)
            {
                radioButton = setup.driver.FindElement(By.CssSelector("#post-10 > div > form > p:nth-child(6) > input[type=\"radio\"]:nth-child(" + option[i] + ")"));

                if (radioButton.GetAttribute("checked") == "true")
                {
                    misc.GreenMessage("The " + i + " radio button checked");
                }
                else
                {
                    misc.RedMessage("Radio button not checked");
                }
            }

            setup.driver.Quit();
            Console.ReadKey();
        }
    }
}
