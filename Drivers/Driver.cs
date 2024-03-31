using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Drivers
{
    internal class Driver

    {
        public static IWebDriver driver { get; set; }
        public Driver() { }

        public static void Initialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        public static void Shutdown()
        {
               driver.Quit();
        }


    }
}
