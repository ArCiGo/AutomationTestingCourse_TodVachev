using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ElementSelectors
{
    class ClassNameSelectors
    {
        static void Main(string[] args)
        {
            Setup setup = new Setup();
            Miscellaneous misc = new Miscellaneous();
            IWebElement element;

            string url = "http://testing.todvachev.com/selectors/class-name/";
            string className = "testClass";

            setup.driver.Navigate().GoToUrl(url);
            element = setup.driver.FindElement(By.ClassName(className));

            Console.WriteLine(element.Text);

            setup.driver.Quit();
            Console.ReadKey();
        }
    }
}
