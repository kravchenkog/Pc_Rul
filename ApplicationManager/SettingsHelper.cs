using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace PC_Rul_Tests
{
    public class SettingsHelper : HelperBase
    {
        private EnvironmentData baseUrl;

        public SettingsHelper(ApplicationManager apManager, EnvironmentData baseUrl) : base(apManager)
        {
            this.apManager = apManager;
            this.baseUrl = baseUrl;
        }

        public bool SettingsPopupIsPresented_FirstStart()
        {
            for(int i = 0; i < 1000; i++)
            {
                Thread.Sleep(5);
                if (IsElementPresent(By.CssSelector("div[class='settings-popup-container']"))&& driver.FindElement(By.CssSelector("div[class='settings-popup-container']")).Displayed)
                {
                        return true;
                }
            }
            return false;    
        }
        public List<double> GetSelectedLowLimitsInSettings()
        {
            apManager.Table.Settings_Tap();
            List<string> limitsLow = new List<string>();
            List<double> limitsLow_double = new List<double>();
            limitsLow.Add(GetValueForLowLimitMin());
            limitsLow.Add(GetValueForLowLimitMax());

            for(int i =0; i<limitsLow.Count; i++)
            {
                limitsLow_double.Add(Double.Parse(limitsLow[i].Substring(1)));
                
            }
            limitsLow.Sort();
            SelectLimit(1);
            SaveButton_Tap();
            return limitsLow_double;
            
        }
        public List<double> GetSelectedNormalLimitsInSettings()
        {
            apManager.Table.Settings_Tap();
            List<string> limits = new List<string>();
            List<double> limits_double = new List<double>();
            limits.Add(GetValueForNormalLimitMin());
            limits.Add(GetValueForNormalLimitMax());

            for (int i = 0; i < limits.Count; i++)
            {
                limits_double.Add(Double.Parse(limits[i].Substring(1)));

            }
            limits.Sort();
            SelectLimit(2);
            SaveButton_Tap();
            return limits_double;
        }
        public List<double> GetSelectedHighLimitsInSettings()
        {
            apManager.Table.Settings_Tap();
            List<string> limits = new List<string>();
            List<double> limits_double = new List<double>();
            limits.Add(GetValueForHighlLimitMin());
            limits.Add(GetValueForHighlLimitMax());

            for (int i = 0; i < limits.Count; i++)
            {
                limits_double.Add(Double.Parse(limits[i].Substring(1)));

            }
            limits.Sort();
            SelectLimit(3);
            SaveButton_Tap();
            return limits_double;
        }
        public void SaveButton_Tap()
        {
            driver.FindElement(By.Id("save_settings")).Click();
        }

        public string GetValueForNormalLimitMax()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.CssSelector("div[class='settings-popup-container']"))));
            return driver.FindElement(By.CssSelector("label[for='limit_norm'] span[data-name='maxLimit']")).Text;
        }

        public void SelectLimitAndSave(int limitLevel)
        {
            apManager.Table.Settings_Tap();
            SelectLimit(limitLevel);
            SaveButton_Tap();
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(ExpectedConditions.ElementIsVisible(By.Id("spin_button")));
        }

        private void SelectLimit(int limit)
        {
            switch (limit)
            {
                case 1:
                    LimitLow_Tap();
                    break;
                case 2:
                    LimitNormal_Tap();
                    break;
                case 3:
                    LimitHigh_Tap();
                    break;
            }
        }

        private void LimitLow_Tap()
        {
            driver.FindElement(By.CssSelector("label[for='limit_low']")).Click();
        }

        private void LimitNormal_Tap()
        {
            driver.FindElement(By.CssSelector("label[for='limit_norm']")).Click();
        }

        private void LimitHigh_Tap()
        {
            driver.FindElement(By.CssSelector("label[for='limit_high']")).Click();
        }

        public bool PaytaleButtonPresents()
        {

            if (IsElementPresent(By.CssSelector("span[data-text='PAYTABLE']")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool PayTableOpens()
        {
            IWebElement payTableButton = driver.FindElement(By.CssSelector("span[data-text='PAYTABLE']"));
            payTableButton.Click();
            Thread.Sleep(100);
            if (driver.FindElement(By.Id("paytable_area")).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool SettingsButtonPresents()
        {
            if (IsElementPresent(By.CssSelector("button#settings_button span[data-text='SETTINGS']")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

        public string GetValueForHighlLimitMin()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.CssSelector("div[class='settings-popup-container']"))));
            return driver.FindElement(By.CssSelector("label[for='limit_high'] span[data-name='minLimit']")).Text;
        }

        

        public string GetValueForHighlLimitMax()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.CssSelector("div[class='settings-popup-container']"))));
            return driver.FindElement(By.CssSelector("label[for='limit_high'] span[data-name='maxLimit']")).Text;

        }

        internal bool TurboSectionPresents()
        {
            if(IsElementPresent(By.CssSelector("section h2[class='section-title turbo-icon']")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetValueForNormalLimitMin()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.CssSelector("div[class='settings-popup-container']"))));
            return driver.FindElement(By.CssSelector("label[for='limit_norm'] span[data-name='minLimit']")).Text;
        }

        public string GetValueForLowLimitMax()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.CssSelector("div[class='settings-popup-container']"))));
            return driver.FindElement(By.CssSelector("label[for='limit_low'] span[data-name='maxLimit']")).Text;
        }

        public string GetValueForLowLimitMin()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(ExpectedConditions.ElementExists((By.CssSelector("div[class='settings-popup-container']"))));
            return driver.FindElement(By.CssSelector("label[for='limit_low'] span[data-name='minLimit']")).Text;
        }

        internal bool TurboButtonsPresent()
        {
            if (IsElementPresent(By.CssSelector("label[for='sound_off']")) && IsElementPresent(By.CssSelector("label[for='sound_on']")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChoseTableSectionIsPresented()
        {
            if (IsElementPresent(By.CssSelector("section h2[class='section-title table-icon']")) 
                && driver.FindElement(By.CssSelector("section h2[class='section-title table-icon']")).Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChoseTableButtonsPresent()
        {
            if (IsElementPresent(By.CssSelector("label[for='table_color_blue']")) 
                && IsElementPresent(By.CssSelector("label[for='table_color_green']"))
                && IsElementPresent(By.CssSelector("label[for='table_color_black']"))
                && IsElementPresent(By.CssSelector("label[for='table_color_red']")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SettingPopupClosed_AfterStart()
        {
            driver.FindElement(By.Id("save_settings")).Click();
            Thread.Sleep(500);
            return driver.FindElement(By.Id("settings_area")).Displayed;
           
        }
    }
}
