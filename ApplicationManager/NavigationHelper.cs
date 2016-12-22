using System;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace PC_Rul_Tests
{
    public class NavigationHelper : HelperBase
    {
        private EnvironmentData baseUrl;
        public NavigationHelper(ApplicationManager apManager, EnvironmentData baseUrl) : base(apManager)
        {
            this.apManager = apManager;
            this.baseUrl = baseUrl;
        }

        public void GoToHomeScreen(string localisation)
        {
            switch (localisation)
            {
                case "english":
                    if (GetCurrentURL() != baseUrl.English)
                    {
                        StartNewHomeScreen(baseUrl.English);
                        break;
                    }
                    else
                    {
                        
                        if (SettingsPopupDispay())
                        {
                            apManager.Settings.SaveButton_Tap();
                            break;
                        }
                        break;
                    }
                case "italy":
                    if (GetCurrentURL() != baseUrl.Italy)
                    {
                        driver.Navigate().GoToUrl(baseUrl.Italy);
                        new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists((By.Id("settings_button"))));
                        break;
                    }
                    else
                    {
                        ChekThatSettingsIsOpened();
                        break;
                    }
            }
        }

        public void GoToHomeScreen_SettingsPopupAfterFirstStart(string localization)
        {
            switch (localization)
            {
                case "english":
                    if(GetCurrentURL() != baseUrl.English)
                    {
                        driver.Manage().Cookies.DeleteAllCookies();
                        StartNewHomeScreen(baseUrl.English);
                        break;
                    }
                    else
                    {
                        if (SettingsPopupDispay() == false)
                        {
                           
                            break;
                        }
                        ChekThatSettingsIsOpened();
                        break;
                    }
                case "italy":
                    if (GetCurrentURL() != baseUrl.Italy)
                    {
                        driver.Navigate().GoToUrl(baseUrl.Italy);
                        new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementExists((By.Id("settings_button"))));
                        break;
                    }
                    else
                    {
                        ChekThatSettingsIsOpened();
                        break;
                    }
            }
        }

        private void StartNewHomeScreen(string urla)
        {
            driver.Navigate().GoToUrl(urla);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("settings_button"))));
            
            
        }

        private bool SettingsPopupDispay()
        {
            return driver.FindElement(By.Id("settings_popup")).Displayed;
        }

        private void ChekThatSettingsIsOpened()
        {
            if (driver.FindElement(By.Id("paytable_area")).Displayed)
            {
                IWebElement settingsTitleButton = settings_TitleButton();
                settingsTitleButton.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(2)).
                    Until(ExpectedConditions.ElementIsVisible(By.Id("settings_area")));
            }
        }
        private IWebElement settings_TitleButton()
        {
            return driver.FindElement(By.CssSelector("label[for='settings_check']"));
        }
        private string GetCurrentURL()
        {
            return driver.Url;
        }
    }
}
