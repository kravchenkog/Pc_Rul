using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PC_Rul_Tests
{
    public class ButtonsHelper : HelperBase
    {
        private EnvironmentData baseUrl;
        public ButtonsHelper(ApplicationManager apManager, EnvironmentData baseUrl) : base(apManager)
        {
            this.apManager = apManager;
            this.baseUrl = baseUrl;
        }

        public bool SettingsButtonIsPresented()
        {

            if (IsElementPresent(By.Id("settings_button")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LimitSectionIsPresented_FirstStart_Test()
        {
            bool a = IsElementPresent(By.CssSelector("h2[class='section-title limits-icon']"));
            if(a == true)
            {
                return driver.FindElement(By.CssSelector("h2[class='section-title limits-icon']")).Displayed;
            }
            else
            {
                return false;
            }
        }

        public bool SettingsPopupIsOpened()
        {
            if (!IsElementPresent(By.Id("settings_button")))
            {
                Console.WriteLine("'Settings' button is not presented");
                return false;
            }
            else
            {
                driver.FindElement(By.Id("settings_button")).Click();
                if (IsElementPresent(By.Id("settings_area")))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

       
    }
}
