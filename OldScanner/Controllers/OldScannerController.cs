using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using OldScanner.Models;
using OldScanner.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OldScanner.Controllers
{
    public class OldScannerController : Controller
    {
        private string url = "https://www.planetwin365.it/it/scommesse";

        private IBrowserDriverRepository _browserDriverRepository;
        private ChromeDriver _chromeDriver;

        ILastMinuteRepository _lastMinuteRepository;
        public OldScannerController(IBrowserDriverRepository browserDriverRepository, ILastMinuteRepository lastMinuteRepository)
        {
            _browserDriverRepository = browserDriverRepository;
            _chromeDriver = browserDriverRepository.GetChromeDriver();
            _chromeDriver.Navigate().GoToUrl(url);
            _lastMinuteRepository = lastMinuteRepository;
        }

        public IActionResult GetLastMinute()
        {

            IWebElement rootItem = _chromeDriver.FindElementByCssSelector("#NESportCnt > div.itemSport > div.items");
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

                _lastMinuteRepository.AddLastMinute(lastMinute);
            }

            _chromeDriver.Quit();

            return View(lastMinutesList);
        }
    }
}
