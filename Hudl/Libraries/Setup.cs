using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace Hudl.Libraries
{
    public class Setup
    {

        public static IWebDriver driver;

        public Setup()
        {
            if (driver == null)
            {
              string Browser = ConfigurationManager.AppSettings.Get("Browser");
                if (Browser == "Chrome")
                {
                    driver = GetChromeDriver();
                }
                driver.Manage().Window.Maximize();
            }
        }


        private IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            ChromeOptions options = new ChromeOptions();

            options.AddArguments("test-type");
            options.AddArguments("start-maximized");
            options.AddArguments("--js-flags=--expose-gc");
            options.AddArguments("--enable-precise-memory-info");
            options.AddArguments("--disable-default-apps");
            options.AddArguments("--enable-automation");
            options.AddArguments("--whitelisted-ips=\"\"");
            options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-extensions");
            options.AddArguments("test-type=browser");
            options.AddArguments("disable-infobars");
            options.AddArguments("disable-extensions");
            return driver;
        }

        [BeforeScenario]
        public static IWebDriver getdriver()
        {
            if (driver == null)
            {

                return driver;
            }
            else
            {
                return driver;
            }
        }

        public static IWebElement WaitForElement(IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }



        [AfterFeature]
        public static void Quit()
        {

            driver.Quit();
        }
    }
}
