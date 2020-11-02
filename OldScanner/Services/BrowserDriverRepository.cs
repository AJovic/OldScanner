using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldScanner.Services
{
    public class BrowserDriverRepository : IBrowserDriverRepository
    {
        public ChromeDriver GetChromeDriver()
        {

            var chromeOptions = new ChromeOptions() { Proxy = null }; ;
            chromeOptions.AddArguments(new List<string>() {
            "--silent-launch",
            "--no-startup-window",
            "no-sandbox",
            "headless"
            });

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;

            ChromeDriver driver = new ChromeDriver(chromeDriverService, chromeOptions);

            return driver;
        }

    }
}
