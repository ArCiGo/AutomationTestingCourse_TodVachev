using System;
using System.Collections.Generic;
using System.IO;
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

            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\ExtractedContent");

            List<string> extractedLinks = new List<string>();
            List<string> extractedTitle = new List<string>();
            List<string> extractedContent = new List<string>();

            IWebDriver driver = new ChromeDriver(options);
            IWebElement titleElement;
            IWebElement contentElement;
            IAlert alert;

            string siteMapURL = @"http://testing.todvachev.com/sitemap-posttype-post.xml";
            string titleSelector = "#main-content > article > header > h1";
            string contentSelector = "#main-content > article > div";
            string path = "";

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

            foreach (var item in extractedLinks)
            {
                driver.Navigate().GoToUrl(item);

                if(item == "http://testing.todvachev.com/special-elements/alert-box/")
                {
                    alert = driver.SwitchTo().Alert();
                    alert.Accept();

                    titleElement = driver.FindElement(By.CssSelector(titleSelector));
                    contentElement = driver.FindElement(By.CssSelector(contentSelector));
                } else
                {
                    titleElement = driver.FindElement(By.CssSelector(titleSelector));
                    contentElement = driver.FindElement(By.CssSelector(contentSelector));
                }

                extractedTitle.Add(titleElement.Text);
                extractedContent.Add(contentElement.Text);
            }

            for (int i = 0; i < extractedTitle.Count; i++)
            {
                path = String.Format(Directory.GetCurrentDirectory() + @"\ExtractedContent\0{0} {1}.txt", i, extractedTitle[i]);

                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Title: {0}", extractedTitle[i]);
                    sw.WriteLine("Content");
                    sw.Write(extractedContent[i]);
                }
            }
        }
    }
}
