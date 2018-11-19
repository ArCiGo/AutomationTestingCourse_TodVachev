using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ElementSelectors
{
    class IDSelectors
    {
        static void Main(string[] args)
        {
            Setup setup = new Setup();
            Miscellaneous misc = new Miscellaneous();
            IWebElement element;

            string url = "http://testing.todvachev.com/selectors/id/";
            string ID = "testImage";

            setup.driver.Navigate().GoToUrl(url);
            element = setup.driver.FindElement(By.Id(ID));

            if (element.Displayed)
            {
                misc.GreenMessage("Yes, I can see it!");
            }
            else
            {
                misc.RedMessage("No, I can't see it");
            }

            setup.driver.Quit();
        }
    }
}
