using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SizeAndPosition
{
    class Program
    {
        static void Main(string[] args)
        {
            Size size = new Size();

            size.Width = 600;
            size.Height = 600;

            Point position = new Point();
            position.X = 0; // or -5
            position.Y = 0; // with negative values, X or Y, the window should be displayed at the corner of the screen

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://testing.todvachev.com");
            driver.Manage().Window.Size = size;
            driver.Manage().Window.Position = position;
        }
    }
}
