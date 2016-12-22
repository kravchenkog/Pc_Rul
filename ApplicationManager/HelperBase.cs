using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PC_Rul_Tests
{
    public class HelperBase
    {
        protected IWebDriver driver;
        protected ApplicationManager apManager;


        public HelperBase(ApplicationManager apManager)
        {
            this.apManager = apManager;
            driver = apManager.Driver;

        }
        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }

        }
        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
