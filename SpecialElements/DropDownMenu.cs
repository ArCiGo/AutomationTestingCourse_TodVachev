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
    class DropDownMenu
    {
        static void Main(string[] args)
        {
            Setup setup = new Setup();
            Miscellaneous misc = new Miscellaneous();
            IWebElement dropDownMenu;
            IWebElement elementFromDropDownMenu;

            string url = "http://testing.todvachev.com/special-elements/drop-down-menu-test/";
            string dropDownMenuElements = "#post-6 > div > p:nth-child(6) > select > option:nth-child(3)";

            setup.driver.Navigate().GoToUrl(url);

            dropDownMenu = setup.driver.FindElement(By.Name("DropDownTest"));
            Console.WriteLine("The selected value is" + dropDownMenu.GetAttribute("value"));

            elementFromDropDownMenu = setup.driver.FindElement(By.CssSelector(dropDownMenuElements));
            Console.WriteLine("The third option is: " + elementFromDropDownMenu.GetAttribute("value"));
            elementFromDropDownMenu.Click();
            Console.WriteLine("The selected value is: " + dropDownMenu.GetAttribute("value"));

            for (int i = 1; i <= 4; i++)
            {
                dropDownMenuElements = "#post-6 > div > p:nth-child(6) > select > option:nth-child(" + i + ")";
                elementFromDropDownMenu = setup.driver.FindElement(By.CssSelector(dropDownMenuElements));

                Console.WriteLine("The " + i + " option from the dropdown menu is: " + elementFromDropDownMenu.GetAttribute("value"));
            }

            Thread.Sleep(15000);

            setup.driver.Quit();
            Console.ReadKey();
        }
    }
}
