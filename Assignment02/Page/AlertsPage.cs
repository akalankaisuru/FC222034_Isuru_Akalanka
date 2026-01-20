using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Assignment02.Page
{
    public class AlertsPage
    {
        private readonly IWebDriver driver;
        public AlertsPage(IWebDriver driver) => this.driver = driver;

        
        private readonly By AlertBtn = By.Id("alertButton");
        private readonly By ConfirmBtn = By.Id("confirmButton");
        private readonly By PromptBtn = By.Id("promptButton");

        public void NavigateTo() => driver.Navigate().GoToUrl("https://uitestingplayground.com/alerts");

        public bool AreButtonsVisible() =>
            driver.FindElement(AlertBtn).Displayed &&
            driver.FindElement(ConfirmBtn).Displayed &&
            driver.FindElement(PromptBtn).Displayed;

        public void ClickAlertButton() => driver.FindElement(AlertBtn).Click();
        public void ClickConfirmButton() => driver.FindElement(ConfirmBtn).Click();
        public void ClickPromptButton() => driver.FindElement(PromptBtn).Click();

        
        public string GetAlertTextAndAccept()
        {
            IAlert alert = driver.SwitchTo().Alert();
            string? text = alert.Text;
            alert.Accept();
            return text ?? string.Empty;
        }

        
        public void EnterTextAndAccept(string text)
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();
        }

        public void HandleConfirm(bool accept)
        {
            IAlert alert = driver.SwitchTo().Alert();
            if (accept) alert.Accept();
            else alert.Dismiss();
        }
    }
}