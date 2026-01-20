using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Assignment02.Page
{
    public class SampleAppPage
    {
        private readonly IWebDriver driver;
        public SampleAppPage(IWebDriver driver) => this.driver = driver;

        private readonly By UserNameField = By.Name("UserName");
        private readonly By PasswordField = By.Name("Password");
        private readonly By LoginButton = By.Id("login");
        private readonly By LoginStatus = By.Id("loginstatus");

        public void NavigateTo() => driver.Navigate().GoToUrl("https://uitestingplayground.com/sampleapp");

        public bool AreElementsDisplayed() =>
            driver.FindElement(UserNameField).Displayed &&
            driver.FindElement(PasswordField).Displayed &&
            driver.FindElement(LoginButton).Displayed;

        public void Login(string user, string pass)
        {
            driver.FindElement(UserNameField).SendKeys(user);
            driver.FindElement(PasswordField).SendKeys(pass);
            driver.FindElement(LoginButton).Click();
        }

        public string GetStatusText() => driver.FindElement(LoginStatus).Text;
    }
}