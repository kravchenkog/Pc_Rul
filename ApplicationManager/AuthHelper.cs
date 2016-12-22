using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace PC_Rul_Tests
{
    public class AuthHelper : HelperBase
    {
        public AuthHelper(ApplicationManager apManager) : base(apManager)
        {
            this.apManager = apManager;
        }

        internal void TapRebet()
        {
            if (driver.FindElement(By.Id("rebet_button")).Displayed)
            {
                driver.FindElement(By.Id("rebet_button")).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(2))
                    .Until(ExpectedConditions.ElementIsVisible(By.Id("spin_button")));
            }
           
        }

        public void CloseSettings()
        {
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart("english");
            if (SettingsPopupOpened() )
            {
                apManager.Settings.SaveButton_Tap();
            }
            else
            {
                return;
            }
        }

        private bool SettingsPopupOpened()
        {
            return driver.FindElement(By.Id("settings_area")).Displayed;
        }

      
    }
}
