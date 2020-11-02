using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OldScanner.Services
{
    public interface IBrowserDriverRepository
    {
        ChromeDriver GetChromeDriver();
    }
}
