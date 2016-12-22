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
    public class TableHelper : HelperBase
    {
        public TableHelper(ApplicationManager apManager) : base(apManager)
        {
            this.apManager = apManager;
        }
        public void PerformWin()
        {
            SettingBetToRed();
            SettingBetToBlack();
            SpinButton_Tap();
            WaitUntilRoundEnd();
           
        }
        public void PerformRoundWithoutWin()
        {
            SpinButton_Tap();
            WaitUntilRoundEnd();
        }
        public void PerformWinAndTapRebetButton()
        {
            SettingBetToRed();
            SettingBetToBlack();
            SpinButton_Tap();
            WaitUntilRoundEnd();
            Thread.Sleep(300);
            RebetButton_Tap();
            
        }
        public void SetMaxBetPerTable()
        {
            int maxTable = GetMaxPerTable();
            List<int> chips_values = GetListOfChips_Values();
            IList<IWebElement> chips_elements = GetListOfChips_Elements();
            for (int i = 0; i < chips_values.Count; i++)
            {
                if (maxTable % chips_values[i] == 0)
                {
                    chips_elements[i].Click();
                    int counter = maxTable / chips_values[i];
                    for (int j = 0; j < counter; j++)
                    {
                        if (j % 3 == 0)
                        {
                            apManager.Cell.SetBetToRed("blackred", 1);
                        }
                        else if (j % 2 == 0)
                        {
                            apManager.Cell.SetBetToBlack("blackred", 1);
                        }
                        else
                        {
                            apManager.Cell.TapCell("lowhigh",1);
                        }
                    }
                    return;
                }

            }
            Console.WriteLine("Yakas' hyina");
        }
        public void SetBetMoreThanMaxLimit_PerTable()
        {
            int maxPerTable = GetMaxPerTable();
            int maxChip = GetChipValue(1); //max
            int maxNoBet = maxPerTable / maxChip;
            for (int i = 0; i < maxNoBet + 1; i++)
            {
                if (i == 0)
                {
                    apManager.Cell.TapCell("lowhigh", 1);
                }
                else if (i % 2 == 0)
                {
                    apManager.Cell.SetBetToRed("blackred", 1);
                }
                else
                {
                    apManager.Cell.SetBetToBlack("blackred", 1);
                }
            }

        }
        public void SetMaxBetPerSpot()
        {
            int maxSpot = GetMaxPerSpot();
            List<int> chips_values = GetListOfChips_Values();
            IList<IWebElement> chips_elements = GetListOfChips_Elements();
            for (int i = chips_values.Count; i > 0; i--)
            {
                if (maxSpot % chips_values[i - 1] == 0)
                {
                    int counter = maxSpot / chips_values[i - 1];
                    chips_elements[i - 1].Click();
                    apManager.Cell.SetBetToRed("blackred", counter);
                    return;
                }

            }
            Console.WriteLine("Yakas' hyina");
        }
        public void SetBetMoreThanMaxLimit_PerSpot()
        {
            int maxPerSpot = GetMaxPerSpot();
            int maxChip = GetChipValue(1); //max
            int maxNoBet = maxPerSpot / maxChip;
            apManager.Cell.SetBetToRed("blackred", maxNoBet + 1);
        }
        public List<double> GetLimitsOnTable()
        {
            List<double> limitsOnTable = new List<double>();
            limitsOnTable.Add(Double.Parse(GetMinLimitOnTable()));
            limitsOnTable.Add(Double.Parse(GetMaxLimitOnTable()));
            limitsOnTable.Sort();
            return limitsOnTable;
        }
        public int GetTotalBet_TableCoverage()
        {
            string text = driver.FindElement(By.Id("total-bet")).Text;
            text = text.Substring(1);
            int value = (int)double.Parse(text);
            return value;
        }
        public List<int> GetListOfChips_Values()
        {
            List<int> listChips = new List<int>();
            IList<IWebElement> list = driver.FindElements(By.CssSelector("div#chip-selector span span "));
            foreach (IWebElement a in list)
            {
                listChips.Add(Int32.Parse(a.GetAttribute("innerText")));
            }
            return listChips;
        }
        public void SetMinBetAndStartRound(int counter)
        {
             for(int i=0; i<counter; i++)
            {
                SettingBetToRed();
            }
            SpinButton_Tap();
        }
        private void RebetButton_Tap()
        {
            driver.FindElement(By.Id("rebet_button")).Click();
        }

        public bool AppearingOfWinPopup()
        {
          
            return driver.FindElement(By.Id("win_money_txt")).Displayed;
            
        }

        public void WaitUntilRoundEnd()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(ExpectedConditions.ElementExists(By.CssSelector("div[class='doll start']")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.CssSelector("div[class='doll']")));
        }

        private void SpinButton_Tap()
        {
            driver.FindElement(By.Id("spin_button")).Click();
        }

        private void SettingBetToBlack()
        {
            SelectMinChip();
            apManager.Cell.CellAllBlack_Tap();
            new WebDriverWait(driver, TimeSpan.FromMilliseconds(200));
        }
        private void SettingBetToRed()
        {
            SelectMinChip();
            apManager.Cell.CellAllREd_Tap();
            new WebDriverWait(driver, TimeSpan.FromSeconds(2))
                .Until(ExpectedConditions.ElementExists(By.CssSelector("div#chip_container span span")));
        }

        public IList<IWebElement> GetListOfChips_Elements()
        {
            return driver.FindElements(By.CssSelector("div#chip-selector span.chip"));
        }
        private string GetMaxLimitOnTable()
        {
            return driver.FindElement(By.CssSelector("span#max_value")).Text;
        }

        private string GetMinLimitOnTable()
        {
            return driver.FindElement(By.CssSelector("span#min_value")).Text;
        }

        public bool SpinButtonPresented()
        {
           
            IWebElement SpinButton = driver.FindElement(By.Id("spin_button"));
            return SpinButton.Displayed;
        }

        public bool AutoPlayButtonPresented()
        {
            IWebElement SpinButton = driver.FindElement(By.Id("autoplay_button"));
            return SpinButton.Displayed;
        }

        internal bool LimitsTablePresents()
        {
            return driver.FindElement(By.CssSelector("div.info-texts-container")).Displayed;
        }

        public bool SettingsButtonPresented()
        {
            IWebElement SpinButton = driver.FindElement(By.Id("settings_button"));
            return SpinButton.Displayed;
        }

        public void ClearAllBets()
        {
            if(IsElementPresent(By.CssSelector("button[class='main-button clear-button']")))
            {
                ClearAllBetsButton_Tap();
                return;
            }
            else if(IsElementPresent(By.CssSelector("button[class='main-button remove-bet-button']")))
            {
                ClearBetButton_Tap();
                return;
            }
        }

        

        public void SetSeveralBetsAndTapClearAllButton()
        {
            apManager.Cell.SetBetToRed("blackred", 2);
            ClearAllBetsButton_Tap();
        }

        public bool ClearAllButtonPresets()
        {
            return IsElementPresent(By.CssSelector("button[class='main-button clear-button']"));
        }

        public List<int> GetListOfBets()
        {
            List<int> listOfBets = new List<int>();
            IList<IWebElement> listOfElements = driver.FindElements(By.CssSelector("div#chip_container span span"));
            foreach(IWebElement a in listOfElements)
            {
                listOfBets.Add(Int32.Parse(a.Text));
            }
            return listOfBets;
        }
        public bool LastBetRemovedAfterPressingClear()
        {
            throw new NotImplementedException();
        }

        public void SetDifferBets(int chip_count)
        {

            IList<IWebElement> listofchips = GetListOfChips_Elements();
            listofchips[chip_count].Click();
            apManager.Cell.SetBetToRed("blackred", 1);
        }



        public int GetMaxPerSpot()
        {
            return Int32.Parse(driver.FindElement(By.Id("max_spot_value")).Text);
        }



        public int GetMaxPerTable()
        {
            return Int32.Parse(driver.FindElement(By.Id("max_value")).Text);
        }

        private int GetChipValue(int value)
        {
            List<int> allChips = GetListOfChips_Values();
           

            if(value == 1)
            {
                return allChips.Max();
              
            }
            else if(value == 0)
            {
                 return allChips.Min();
               
            }
            else
            {
                return 0;
            }
            
        }

        public void SetBet(int counter)
        {
            IList<IWebElement> chips = GetListOfChips_Elements();
            chips[counter].Click();
            apManager.Cell.SetBetToRed("blackred", 1);
        }

        public void SetSeveralDiffBets(int number_of_Chips)
        {
            for (int i = 1; i <= number_of_Chips; i++)
            {
                if (i % 2 == 0)
                {
                    apManager.Cell.SetBetToBlack("blackred", 1);
                }
                else
                {
                    apManager.Cell.SetBetToRed("blackred", 1);
                }
            }
        }

        public void PlayRoundAndTapREpeat()
        {
            SpinButton_Tap();
            WaitUntilRoundEnd();
            RebetButton_Tap();
        }

        public void SelectLOwerChipAndSetIT(int chipCounter, int chipNumberToSet)
        {
            IList<IWebElement> listChips = GetListOfChips_Elements();
            listChips[chipCounter].Click();
            apManager.Cell.SetBetToBlack("blackred",chipNumberToSet);
        }

        public double GetTotalBalance_strip()
        {
            string balanseStr = driver.FindElement(By.Id("game_strip_balance_sum")).Text;
            double balance =  Double.Parse(balanseStr.Substring(1).Replace(",", ""));
            return balance;

        }
        public void SelectMinChip()
        {
            IList<IWebElement> listOfChips = GetListOfChips_Elements();
            listOfChips[0].Click();
        }
        public void SelectMaxChip()
        {
            IList<IWebElement> listOfChips = GetListOfChips_Elements();
            listOfChips[listOfChips.Count - 1].Click();
        }
       
        public void ClearBetButton_Tap()
        {
            driver.FindElement(By.CssSelector
                ("button[class='main-button remove-bet-button']")).Click();
        }
        public void SetSeveralTheSameChips(int chip_count)
        {
            IList<IWebElement> listofchips = GetListOfChips_Elements();
            listofchips[chip_count].Click();
            apManager.Cell.SetBetToRed("blackred", 3);
            
        }
        public void ClearAllBetsButton_Tap()
        {
            driver.FindElement(By.CssSelector
                ("button[class='main-button clear-button']")).Click();
        }

        public bool ChipButtonsPresented()
        {
            IList<IWebElement> chips = driver.FindElements(By.CssSelector("div#chip-selector span.chip"));
            if(chips.Count >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool ClearButtonPresets()
        {
            return IsElementPresent(By.CssSelector("button[class='main-button remove-bet-button']"));

        }
        
       
        
        public void Settings_Tap()
        {
            driver.FindElement(By.Id("settings_button")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(2))
                .Until(ExpectedConditions.ElementIsVisible((By.Id("settings_area"))));

        }

        public void StartSpinAndWaitForStarting()
        {
            SpinButton_Tap();
            new WebDriverWait(driver, TimeSpan.FromSeconds(3))
                .Until(ExpectedConditions.ElementExists(By.CssSelector("div[class='settings-popup-container hidden']")));
        }

        public void SetMinBetStartRoundANDWaitofEnd(int v)
        {
            SetMinBetAndStartRound(v);
            WaitUntilRoundEnd();
        }

        public void StartSpinAndWaitRoundEnds()
        {
            SpinButton_Tap();
            WaitUntilRoundEnd();
        }
    }
}
