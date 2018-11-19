using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ElementSelectors
{
    class CSS_X_PathSelectors
    {
        static void Main(string[] args)
        {
            Setup setup = new Setup();
            Miscellaneous misc = new Miscellaneous();

            string url = "http://testing.todvachev.com/selectors/css-path/";
            string cssPath = "#post > div > figure > img";
            string xPath = "//*[@id=\"post-108\"]/div/figure/img";

            setup.driver.Navigate().GoToUrl(url);

            IWebElement cssPathElement;
            IWebElement xPathElement = setup.driver.FindElement(By.XPath(xPath));

            try
            {
                cssPathElement = setup.driver.FindElement(By.CssSelector(cssPath));

                if (cssPathElement.Displayed)
                {
                    misc.GreenMessage("I can see the CSS Path element");
                }
            }
            catch (NoSuchElementException ex)
            {
                misc.RedMessage("I can't see the CSS Path element" + ex.Message);
            }

            if (xPathElement.Displayed)
            {
                misc.GreenMessage("I can see the X Path element");
            }
            else
            {
                misc.RedMessage("I can't see the X Path element");
            }

            setup.driver.Quit();
            Console.ReadKey();
        }
    }
}
