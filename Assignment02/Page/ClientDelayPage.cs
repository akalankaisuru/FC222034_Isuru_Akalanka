using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Assignment02.Page
{
    public class ClientDelayPage
    {
        private readonly IWebDriver driver;

        public ClientDelayPage(IWebDriver driver) => this.driver = driver;

        
        private readonly By TriggerButton = By.Id("ajaxButton");
        private readonly By SuccessBanner = By.CssSelector(".bg-success");

        public void NavigateTo() => driver.Navigate().GoToUrl("https://uitestingplayground.com/clientdelay");

        public bool IsButtonVisible() => driver.FindElement(TriggerButton).Displayed;

        public void ClickTriggerButton() => driver.FindElement(TriggerButton).Click();

        public string GetSuccessMessageText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            IWebElement banner = wait.Until(ExpectedConditions.ElementIsVisible(SuccessBanner));
            return banner.Text;
        }
    }
}