using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecialElements
{
    class Setup
    {
        public IWebDriver driver = new ChromeDriver();
    }
}
