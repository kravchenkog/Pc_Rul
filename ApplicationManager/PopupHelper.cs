using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace PC_Rul_Tests
{
    public class PopupHelper : HelperBase
    {
       
        public PopupHelper(ApplicationManager apManager) : base(apManager)
        {
            this.apManager = apManager;
        }
        
        
        public void ClosePopup()
        {
            if (IsElementPresent(By.CssSelector("div.rl_message_body")))
            {
                if (IsElementPresent(By.CssSelector("input[value='OK']")))
                {
                    driver.FindElement(By.CssSelector("input[value='OK']")).Click();
                    
                    return;
                }
            }
        }

        public void WaitUntilRoundHasBeenFinished()
        {
            if(IsElementPresent(By.CssSelector("button[class='main-button spin-button hidden']")) == true
                &&IsElementPresent(By.CssSelector("button[class='main-button rebet-button hidden']")) == true)
            {
                apManager.Table.WaitUntilRoundEnd();
            }
        }

        public bool PopupMessageIsAppeared()
        {
            return driver.FindElement(By.CssSelector("div.rl_message_body")).Displayed;
        }
    }
}
