using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Assignment02.Page;

namespace Assignment02.Test
{
    [TestFixture]
    public class ClientDelayTests
    {
        private ChromeDriver driver;
        private ClientDelayPage delayPage;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            
            delayPage = new ClientDelayPage(driver);
        }

        [Test]
        [Description("TC003_1 - Client Side Delay - Verification of the page")]
        public void TC003_1_ClientSideDelay_Verification()
        {
            
            delayPage.NavigateTo();

            
            NUnit.Framework.Assert.That(delayPage.IsButtonVisible(), Is.True, "Button to trigger logic is not visible.");

           
            delayPage.ClickTriggerButton();

            
            string expectedMessage = "Data calculated on the client side.";
            string actualMessage = delayPage.GetSuccessMessageText();

            
            NUnit.Framework.Assert.That(actualMessage, Is.EqualTo(expectedMessage), "The success banner text does not match.");
        }

        [TearDown]
        public void TearDown()
        {
            
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
