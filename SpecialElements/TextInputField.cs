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
    class TextInputField
    {
        static void Main(string[] args)
        {
            Setup setup = new Setup();
            Miscellaneous misc = new Miscellaneous();
            IWebElement textBox;

            string url = "http://testing.todvachev.com/special-elements/text-input-field/";

            setup.driver.Navigate().GoToUrl(url);

            textBox = setup.driver.FindElement(By.Name("username"));
            textBox.SendKeys("Test text");

            Thread.Sleep(3000);

            //textBox.Clear();
            Console.WriteLine(textBox.GetAttribute("value"));
            Console.WriteLine(textBox.GetAttribute("maxlength"));

            Thread.Sleep(3000);

            setup.driver.Quit();
            Console.ReadKey();
        }
    }
}
