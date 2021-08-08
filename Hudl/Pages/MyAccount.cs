using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hudl.Libraries;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Hudl.Pages
{
    class MyAccount : Setup
    {
        private By displayName = By.CssSelector("div.hui-globaluseritem__display-name");
        private By signOut = By.XPath("//div[@class='hui - globalusermenu__items']//a[@href='/logout']");
        new readonly IWebDriver driver = getdriver();

        public string verifyDisplayname()
        {
           string display_name = WaitForElement(driver, displayName, 1000).Text;
            return display_name;
        }

        public void SignOut()
        {
            //driver.FindElement(displayName).Click();
            //Actions action = new Actions(driver);
            //action.MoveToElement(driver.FindElement(signOut)).Click().Build().Perform();
            ////driver.FindElement(signOut).Click();
            driver.Navigate().GoToUrl("https://www.hudl.com/logout");
        }

        private object WaitForElement((IWebDriver driver, By signOut, int) p)
        {
            throw new NotImplementedException();
        }

        public string verifyEmail()
        {
            string emailVerifcation = WaitForElement(driver, displayName, 1000).Text;
            return emailVerifcation; 
        }


    }
}
