using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using OldScanner.Config;
using OldScanner.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OldScanner.Controllers
{
    public class OldScannerController : Controller
    {
        private string url = "https://www.planetwin365.it/it/scommesse";
        private ChromeDriver _driver;

        public OldScannerController()
        {
            _driver = BrowserDriver.GetChromeDriver();
            _driver.Navigate().GoToUrl(url);
        }

        public IActionResult GetLastMinute()
        {

            IWebElement rootItem = _driver.FindElementByCssSelector("#NESportCnt > div.itemSport > div.items");
            ReadOnlyCollection<IWebElement> childItems = rootItem.FindElements(By.ClassName("col7"));

            List<LastMinute> lastMinutesList = new List<LastMinute>();

            foreach (var childItem in childItems)
            {
                LastMinute lastMinute = new LastMinute();

                string data = childItem.FindElement(By.ClassName("data")).Text;
                string time = childItem.FindElement(By.ClassName("time")).Text;
                string events = childItem.FindElement(By.ClassName("event")).Text;
                string subEvent = childItem.FindElement(By.ClassName("subevent")).Text;
                ReadOnlyCollection<IWebElement> odsItems = childItem.FindElements(By.TagName("a"));

                lastMinute.Data = data;
                lastMinute.Time = time;
                lastMinute.Event = events;
                lastMinute.SubEvent = subEvent;

                lastMinute.One = odsItems[1].Text;
                lastMinute.X = odsItems[2].Text;
                lastMinute.Two = odsItems[3].Text;
                lastMinute.Over = odsItems[4].Text;
                lastMinute.Under = odsItems[5].Text;
                lastMinute.CG = odsItems[6].Text;
                lastMinute.NG = odsItems[7].Text;

                lastMinutesList.Add(lastMinute);
            }

            _driver.Close();

            return View(lastMinutesList);
        }
    }
}
