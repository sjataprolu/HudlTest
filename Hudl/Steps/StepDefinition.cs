using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hudl.Libraries;
using Hudl.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace Hudl.Steps
{
    [Binding]
    class StepDefinition :Setup
    {


        [Given(@"I login with username as ""(.*)""and Password as ""(.*)""")]
        public void GivenILoginWithUsernameAsAndPasswordAs(string p0, string p1)
        {
            string hudlurl = ConfigurationManager.AppSettings.Get("URL");
            driver.Navigate().GoToUrl(hudlurl);
            new LoginPage().Login(p0, p1);
        }


        [Then(@"I should be able to see myaccount as ""(.*)""")]
        public void ThenIShouldBeAbleToSeeMyaccountAs(string p0)
        {
            Assert.AreEqual(new MyAccount().verifyDisplayname(), p0);
            new MyAccount().SignOut();
        }

        [Then(@"I should be to see error message ""(.*)""")]
        public void ThenIShouldBeToSeeErrorMessage(string p0)
        {
            string error = new LoginPage().ErrorMessage();
            Assert.AreEqual(error, p0);
        }



    }
}
