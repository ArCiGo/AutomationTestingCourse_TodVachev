using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ElementSelectors
{
    class NameSelectors
    {
        static void Main(string[] args)
        {
            Setup setup = new Setup();
            Miscellaneous misc = new Miscellaneous();
            IWebElement element;

            setup.driver.Navigate().GoToUrl("http://testing.todvachev.com/selectors/name/");
            element = setup.driver.FindElement(By.Name("myName"));

            if (element.Displayed)
            {
                misc.GreenMessage("Yes! I can see the element");
            }
            else
            {
                misc.RedMessage("I can't see the element");
            }

            setup.driver.Quit();
        }
    }
}
