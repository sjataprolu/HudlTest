using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hudl.Libraries;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Hudl.Pages
{
    class LoginPage:Setup
    {
        new readonly IWebDriver driver = getdriver();

        private By loginLink = By.CssSelector("li.nav-button a[href$='/login']");
        private By emailTextBox = By.Id("email");
        private By passwordTextBox = By.Id("password");
        private By loginButton = By.Id("logIn");
        private By ErrorMsgLabel = By.CssSelector("div.login-error-container");



        public void Login(string username,string password)
        {
            WaitForElement(driver, loginLink, 1000).Click();
            WaitForElement(driver, emailTextBox, 1000).SendKeys(username);
            WaitForElement(driver, passwordTextBox, 1000).SendKeys(password);
            WaitForElement(driver, loginButton, 1000).Click();
        }

        public string ErrorMessage()
        {
            string msg= WaitForElement(driver, ErrorMsgLabel, 1000).Text;
            return msg;
        }


    }
}
