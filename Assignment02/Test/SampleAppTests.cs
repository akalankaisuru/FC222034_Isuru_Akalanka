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
    public class SampleAppTests
    {
        private ChromeDriver driver; 
        private SampleAppPage page;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            page = new SampleAppPage(driver);
        }

        [Test, Description("TC002_1")]
        public void VerificationOfPage()
        {
            page.NavigateTo();
            Assert.That(page.AreElementsDisplayed(), Is.True);
        }

        [Test, Description("TC002_2")]
        public void SuccessfulLogin()
        {
            page.NavigateTo();
            page.Login("TestUser", "pwd");
            Assert.That(page.GetStatusText(), Is.EqualTo("Welcome, TestUser!"));
        }

        [Test, Description("TC002_3")]
        public void UnsuccessfulLogin()
        {
            page.NavigateTo();
            page.Login("TestUser", "wrong_pass");
            Assert.That(page.GetStatusText(), Is.EqualTo("Invalid username/password"));
        }

        [TearDown]
        public void Teardown()
        {
            driver?.Dispose(); 
        }
    }
}