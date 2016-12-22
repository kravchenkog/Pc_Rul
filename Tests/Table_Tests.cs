using NUnit.Framework;
using System.Collections.Generic;

namespace PC_Rul_Tests
{
    public class TableTests : AuthTestBase
    { 
        [Test]
        public void When_GameOpened_Expected_SpinButtonDisplayed()
        {
            
            Assert.IsTrue(apManager.Table.SpinButtonPresented());
        }
        [Test]
        public void When_GameOpened_Expected_AutoPlayButtonDisplayed()
        {
            
            Assert.IsTrue(apManager.Table.AutoPlayButtonPresented());
        }
        [Test]
        public void When_GameOpened_Expected_SettingsButtonSisplayed()
        {
            
            Assert.IsTrue(apManager.Table.SettingsButtonPresented());
        }
        [Test]
        public void When_GameOpened_Expected_ChipSelectorPresents_And_ChipsAvailabled()
        {
            
            Assert.IsTrue(apManager.Table.ChipButtonsPresented());
        }
        [Test]
        public void When_GameOpened_Expected_ChipsAreSortedForLowLimit()
        {

            
            apManager.Settings.SelectLimitAndSave(1); // 1 = low limit
            List<int> listOfChipValues_NONsorted = apManager.Table.GetListOfChips_Values();
            List<int> listOfChipValues_sorted = apManager.Table.GetListOfChips_Values();
            listOfChipValues_sorted.Sort();

            Assert.AreEqual(listOfChipValues_NONsorted, listOfChipValues_sorted);
        }
        [Test]
        public void When_GameOpened_Expected_ChipsAreSortedForNormalLimit()
        {

            
            apManager.Settings.SelectLimitAndSave(2); // 2 = Normal limit
            List<int> listOfChipValues_NONsorted = apManager.Table.GetListOfChips_Values();
            List<int> listOfChipValues_sorted = apManager.Table.GetListOfChips_Values();
            listOfChipValues_sorted.Sort();

            Assert.AreEqual(listOfChipValues_NONsorted, listOfChipValues_sorted);
        }
        [Test]
        public void When_GameOpened_Expected_ChipsAreSortedForHighLimit()
        {

           
            apManager.Settings.SelectLimitAndSave(3); // 3 = high limit
            List<int> listOfChipValues_NONsorted = apManager.Table.GetListOfChips_Values();
            List<int> listOfChipValues_sorted = apManager.Table.GetListOfChips_Values();
            listOfChipValues_sorted.Sort();

            Assert.AreEqual(listOfChipValues_NONsorted, listOfChipValues_sorted);
        }
        [Test]
        public void When_RoundWins_Expected_WinPopupPresents()
        {
            apManager.Table.PerformWin();
            Assert.IsTrue(apManager.Table.AppearingOfWinPopup());
        }
        [Test]
        public void When_RoundNOTWins_Expected_WinPopupNOTPresents()
        {
            apManager.Table.PerformRoundWithoutWin();
            Assert.IsFalse(apManager.Table.AppearingOfWinPopup());
        }
        [Test]
        public void When_GameOpened_Expected_LimitsTablePresents()
        {
           
            Assert.IsTrue(apManager.Table.LimitsTablePresents());
        }
        [Test]
        public void When_GameOpened_Expected_LimitsTableForLowLimitsTheSameAsInTheSettingsSelected()
        {
           
            List<double> limitsOnSettings = apManager.Settings.GetSelectedLowLimitsInSettings();
            List<double> limitsOnTable = apManager.Table.GetLimitsOnTable();
            for(int i = 0; i<limitsOnTable.Count; i++)
            {
                Assert.AreEqual(limitsOnSettings[i], limitsOnTable[i]);
            }
            
        }
        [Test]
        public void When_GameOpened_Expected_LimitsTableForNormalLimitsTheSameAsInTheSettingsSelected()
        {
           
            List<double> limitsOnSettings = apManager.Settings.GetSelectedNormalLimitsInSettings();
            List<double> limitsOnTable = apManager.Table.GetLimitsOnTable();
            for (int i = 0; i < limitsOnTable.Count; i++)
            {
                Assert.AreEqual(limitsOnSettings[i], limitsOnTable[i]);
            }

        }

        [Test]
        public void When_GameOpened_Expected_LimitsTableForHighLimitsTheSameAsInTheSettingsSelected()
        {
            
            List<double> limitsOnSettings = apManager.Settings.GetSelectedHighLimitsInSettings();
            List<double> limitsOnTable = apManager.Table.GetLimitsOnTable();
            for (int i = 0; i < limitsOnTable.Count; i++)
            {
                Assert.AreEqual(limitsOnSettings[i], limitsOnTable[i]);
            }

        }

        [Test]
        public void When_BetWasSet_Expected_ClearButtonAppears()
        {
            apManager.Cell.SetBetToRed("blackred", 1);
            Assert.IsTrue(apManager.Table.ClearButtonPresets());
        }

        [Test]
        public void When_SeveralBetsWereSet_Expected_ClearAllButtonAppears()
        {

            apManager.Settings.SelectLimitAndSave(1); //Low
            apManager.Table.SelectMinChip();
            apManager.Cell.SetBetToRed("blackred", 3);
            Assert.IsTrue(apManager.Table.ClearAllButtonPresets());
        }

        [Test]
        public void When_AllBetsWereCleared_Expected_ClearAndClearAllButtonsDisappear()
        {
            apManager.Table.SetSeveralBetsAndTapClearAllButton();

            Assert.IsFalse(apManager.Table.ClearButtonPresets());
            Assert.IsFalse(apManager.Table.ClearAllButtonPresets());
        }
        [Test]
        public void When_ClearButtonPressed_Expected_LastBetRemoved()
        {
            apManager.Settings.SelectLimitAndSave(1);
            apManager.Table.SetSeveralTheSameChips(0); //0 = first chip
            List<int> severalSameBets = apManager.Table.GetListOfBets();
            apManager.Table.SetDifferBets(1);          //1 = second chip
            List<int> severalBets = apManager.Table.GetListOfBets();
            Assert.Less(severalSameBets.Count, severalBets.Count);
            apManager.Table.ClearBetButton_Tap();
            
            List<int> clearedList = apManager.Table.GetListOfBets();
            for(int i = 0; i<clearedList.Count; i++)
            {
                Assert.AreEqual(clearedList[i], severalSameBets[i]);
            }
        }
        [Test]
        public void When_SetBetMoreThanMaxLimitPerSpot_Expected_ErrorMessageAppears()
        {
            apManager.Settings.SelectLimitAndSave(1); //Low
            apManager.Table.SelectMaxChip();
            apManager.Table.SetBetMoreThanMaxLimit_PerSpot();
            Assert.IsTrue(apManager.Popup.PopupMessageIsAppeared());
        }
        [Test]
        public void When_SetBetMoreThanMaxLimitPerTable_Expected_ErrorMessageAppears()
        {
            apManager.Settings.SelectLimitAndSave(1); //Low
            apManager.Table.SelectMaxChip();
            apManager.Table.SetBetMoreThanMaxLimit_PerTable();
            Assert.IsTrue(apManager.Popup.PopupMessageIsAppeared());
        }
        [Test]
        public void When_RebetButtonPressed_Expected_WinPopupDesappears()
        {
            apManager.Table.PerformWinAndTapRebetButton();
            Assert.IsFalse(apManager.Table.AppearingOfWinPopup());
        }
        [Test]
        public void When_BetSeted_Expected_BetRubricIsUpdatedCorrect()
        {
            for(int i = 1; i<=3; i++)
            {
                apManager.Settings.SelectLimitAndSave(i);
                List<int> chips_values = apManager.Table.GetListOfChips_Values();
                
                for(int j = 0; j<chips_values.Count; j++)
                {
                    apManager.Table.SetBet(j);
                    Assert.AreEqual(chips_values[j], apManager.Table.GetTotalBet_TableCoverage());
                    apManager.Table.ClearBetButton_Tap();
                }
            }
        }
        [Test]
        public void When_SetMaxBetPerSpot_Expected_TotalBetShowsCorrectValue()
        {
            apManager.Settings.SelectLimitAndSave(1);//low
            apManager.Table.SetMaxBetPerSpot();
            Assert.AreEqual(apManager.Table.GetMaxPerSpot(), apManager.Table.GetTotalBet_TableCoverage());
        }
        [Test]
        public void When_SetMaxBetPerTable_Expected_TotalBetShowsCorrectValue()
        {
            apManager.Settings.SelectLimitAndSave(3);//high
            apManager.Table.SetMaxBetPerTable();
            Assert.AreEqual(apManager.Table.GetMaxPerTable(), apManager.Table.GetTotalBet_TableCoverage());
        }
        [Test]
        public void When_PressClearButton_Expected_TotalBetShowsNull()
        {
            apManager.Cell.SetBetToRed("blackred",1);
            apManager.Table.ClearBetButton_Tap();
            Assert.AreEqual(apManager.Table.GetTotalBet_TableCoverage(), 0);
        }
        [Test]
        public void When_SetSeveralBets_Expected_TotalBetShowsCorrectValue()
        {
            int number_of_Chips = 2;
            apManager.Settings.SelectLimitAndSave(1);
            List<int> chips_values = apManager.Table.GetListOfChips_Values();
            apManager.Table.SelectMinChip();
            apManager.Table.SetSeveralDiffBets(number_of_Chips);

            Assert.AreEqual(apManager.Table.GetTotalBet_TableCoverage(), chips_values[0]*number_of_Chips);
        }
        [Test]
        public void When_ClearAllButtonPressedAfterSpin_Expected_TotalBetShowsNull()
        {
            int number_of_Chips = 2;
            apManager.Settings.SelectLimitAndSave(1);
            List<int> chips_values = apManager.Table.GetListOfChips_Values();
            apManager.Table.SelectMinChip();
            apManager.Table.SetSeveralDiffBets(number_of_Chips);
            apManager.Table.PlayRoundAndTapREpeat();
            apManager.Table.ClearAllBetsButton_Tap();

            Assert.AreEqual(apManager.Table.GetTotalBet_TableCoverage(), 0);
        }
        [Test]
        public void When_SetSeveralBetsAndTapClearAll_Expected_TotalBetShowsNull()
        {
            int number_of_Chips = 2;
            apManager.Settings.SelectLimitAndSave(1);
            List<int> chips_values = apManager.Table.GetListOfChips_Values();
            apManager.Table.SelectMinChip();
            apManager.Table.SetSeveralDiffBets(number_of_Chips);
            apManager.Table.ClearAllBetsButton_Tap();

            Assert.AreEqual(apManager.Table.GetTotalBet_TableCoverage(), 0);
        }
        [Test]
        public void When_AddBetAfterSpin_Expected_TotalBetCorrect()
        {
            int chipCounter = 0; //0 - lower; 
            int chipNumbertoSet = 2;

            apManager.Settings.SelectLimitAndSave(1); //Low
            List<int> chip_values = apManager.Table.GetListOfChips_Values();
            int lowerChip = chip_values[chipCounter];
            Assert.AreEqual(apManager.Table.GetTotalBet_TableCoverage(), 0);

            apManager.Table.SelectLOwerChipAndSetIT(chipCounter, chipNumbertoSet);
            Assert.AreEqual(apManager.Table.GetTotalBet_TableCoverage(), lowerChip*chipNumbertoSet);

            apManager.Table.PlayRoundAndTapREpeat();
            Assert.AreEqual(apManager.Table.GetTotalBet_TableCoverage(), lowerChip*chipNumbertoSet);

            apManager.Cell.SetBetToRed("blackred",chipNumbertoSet);
            Assert.AreEqual(apManager.Table.GetTotalBet_TableCoverage(), (lowerChip*chipNumbertoSet)*2);
        }
        [Test]
        public void When_OneBetSetedANDPressingSpin_Expected_TotalBetUpdatedcorrect()
        {
            int numberOfChips = 1;

            double old_balance = apManager.Table.GetTotalBalance_strip();
            List<int> chip_list = apManager.Table.GetListOfChips_Values();
            apManager.Table.SetMinBetAndStartRound(numberOfChips);
            double new_balance = apManager.Table.GetTotalBalance_strip();

            Assert.AreEqual(old_balance, new_balance + (chip_list[0])*numberOfChips);
            
            
        }
        [Test]
        public void When_SeveralBetsSetedAndSpinPresed_Expected_TotalBetUpdatedCorrect()
        {
            int numberOfChips = 5;

            double old_balance = apManager.Table.GetTotalBalance_strip();
            List<int> chip_list = apManager.Table.GetListOfChips_Values();
            apManager.Table.SetMinBetAndStartRound(numberOfChips);
            double new_balance = apManager.Table.GetTotalBalance_strip();

            Assert.AreEqual(old_balance, (new_balance + (chip_list[0]*numberOfChips)));
        }
        [Test]
        public void When_SpinButtonPressed_Expected_SpinButtonDontPresent()
        {
            apManager.Table.SetDifferBets(2);
            apManager.Table.StartSpinAndWaitForStarting();
            Assert.IsFalse(apManager.Table.SpinButtonPresented());
        }
        [Test]
        public void When_RebeatButtonPressed_Expected_LastBetAppears()
        {
            int chipCounter = 0; //0 - lower; 

            apManager.Settings.SelectLimitAndSave(1); //Low
            
            apManager.Table.SetBet(chipCounter);
            int totalBet_old = apManager.Table.GetTotalBet_TableCoverage();
            apManager.Table.PlayRoundAndTapREpeat();
            int totalBet_new = apManager.Table.GetTotalBet_TableCoverage();

            Assert.AreEqual(totalBet_old, totalBet_new);
        }
        [Test]
        public void When_WinAnyNumberBet_Expected_WinPopupAppeaers()
        {
            apManager.Settings.SelectLimitAndSave(1);
            apManager.Table.SelectMinChip();
            apManager.Cell.TapCell("number",37);
            apManager.Table.StartSpinAndWaitRoundEnds();
            Assert.IsTrue(apManager.Table.AppearingOfWinPopup());
        }
        [Test]
        public void When_WinAnyDozerBet_Expected_WinPopupAppeaers()
        {
            apManager.Settings.SelectLimitAndSave(1);
            apManager.Table.SelectMinChip();
            apManager.Cell.TapCell("dozer",3);
            apManager.Table.StartSpinAndWaitRoundEnds();
            Assert.IsTrue(apManager.Table.AppearingOfWinPopup());
        }
        [Test]
        public void When_WinAnyColumnBet_Expected_WinPopupAppeaers()
        {
            apManager.Settings.SelectLimitAndSave(1);
            apManager.Table.SelectMinChip();
            apManager.Cell.TapCell("column",3);
            apManager.Table.StartSpinAndWaitRoundEnds();
            Assert.IsTrue(apManager.Table.AppearingOfWinPopup());
        }
        [Test]
        public void When_WinAnyLowHighBet_Expected_WinPopupAppeaers()
        {
            apManager.Settings.SelectLimitAndSave(1);
            apManager.Table.SelectMinChip();
            apManager.Cell.TapCell("lowhigh",2);
            apManager.Table.StartSpinAndWaitRoundEnds();
            Assert.IsTrue(apManager.Table.AppearingOfWinPopup());
        }
        [Test]
        public void When_WinAnyEvenOddBet_Expected_WinPopupAppeaers()
        {
            apManager.Settings.SelectLimitAndSave(1);
            apManager.Table.SelectMinChip();
            apManager.Cell.TapCell("evenodd",2);
            apManager.Table.StartSpinAndWaitRoundEnds();
            Assert.IsTrue(apManager.Table.AppearingOfWinPopup());
        }
        [Test]
        public void When_WinAnyPairBet_Expected_WinPopupAppeaers()
        {
            apManager.Settings.SelectLimitAndSave(1);
            apManager.Table.SelectMinChip();
            apManager.Cell.TapCell("pair", 25);
            apManager.Table.StartSpinAndWaitRoundEnds();
            Assert.IsTrue(apManager.Table.AppearingOfWinPopup());
        }
     
    }
}
