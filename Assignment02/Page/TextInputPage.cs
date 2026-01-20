using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace Assignment02.Page
{
    public class TextInputPage
    {
        private readonly IWebDriver driver;

        
        public TextInputPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private readonly By NewButtonNameInput = By.Id("newButtonName");
        private readonly By UpdatingButton = By.Id("updatingButton");

        
        public void NavigateTo()
        {
            driver.Navigate().GoToUrl("https://uitestingplayground.com/textinput");
        }

        public void EnterButtonText(string text)
        {
            driver.FindElement(NewButtonNameInput).SendKeys(text);
        }

        public void ClickButton()
        {
            driver.FindElement(UpdatingButton).Click();
        }

        public string GetButtonText()
        {
            return driver.FindElement(UpdatingButton).Text;
        }

        
        public bool IsInputDisplayed() => driver.FindElement(NewButtonNameInput).Displayed;
    }
}