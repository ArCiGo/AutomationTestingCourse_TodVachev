using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PhantonProject
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");

            List<string> extractedLinks = new List<string>();
            IWebDriver driver = new ChromeDriver(options);
            string siteMapURL = @"http://testing.todvachev.com/sitemap-posttype-post.xml";
            int startIndex = 0;
            int linkLength = 0;

            driver.Navigate().GoToUrl(siteMapURL);

            string[] pageSource = driver.PageSource.Split(' ');

            foreach (var item in pageSource)
            {
                if(item.Contains(@"href=""http://testing.todvachev.com/"))
                {
                    startIndex = item.IndexOf(@"href=\", StringComparison.CurrentCulture) + 7;
                    linkLength = item.LastIndexOf(@""">", StringComparison.CurrentCulture) - startIndex;

                    extractedLinks.Add(item.Substring(startIndex, linkLength));
                }
            }

            // Console.WriteLine(driver.PageSource);
        }
    }
}
