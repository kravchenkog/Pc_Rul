using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;

namespace PC_Rul_Tests
{
    [TestFixture]
    public class StartingSettingsTests : TestBase
    {
        public string localisation = "english";

        [Test]
        public void When_GameOpensFirstly_Expected_SettingsPopupIsPresented_And_testDurationNoMoreAs10sec()
        {
            
            int startTime = Convert.ToInt32(DateTime.Now.TimeOfDay.TotalSeconds);
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.IsTrue(apManager.Settings.SettingsPopupIsPresented_FirstStart());
            int finishtime = Convert.ToInt32(DateTime.Now.TimeOfDay.TotalSeconds);
            Assert.IsTrue((finishtime-startTime)<=10);
        }
        //TTTLES
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_TitlesPresents()
        {
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.IsTrue(apManager.Settings.SettingsButtonPresents());
            Assert.IsTrue(apManager.Settings.PaytaleButtonPresents());
        }
        //PAYTABLE
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_UserIsAbleToOpenPaytable()
        {
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.IsTrue(apManager.Settings.PayTableOpens());
        }
        //LIMITS
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_LimitSectionPresents()
        {
            
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.IsTrue(apManager.Buttons.LimitSectionIsPresented_FirstStart_Test());
        }

        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_LowLimitMinShouldBeCorrect()
        {
            string lowLimitMin = "$1.00";
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.AreEqual(lowLimitMin, apManager.Settings.GetValueForLowLimitMin());
            
        }
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_LowLimitMaxShouldBeCorrect()
        {
            string lowLimitMax = "$300.00";
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.AreEqual(lowLimitMax, apManager.Settings.GetValueForLowLimitMax());

        }
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_NormalLimitMinShouldBeCorrect()
        {
            string normLimitMin = "$2.00";
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.AreEqual(normLimitMin, apManager.Settings.GetValueForNormalLimitMin());

        }
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_NormalLimitMaxShouldBeCorrect()
        {
            string normLimitMax = "$300.00";
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.AreEqual(normLimitMax, apManager.Settings.GetValueForNormalLimitMax());

        }
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_HighLimitMinShouldBeCorrect()
        {
            string highLimitMin = "$10.00";
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.AreEqual(highLimitMin, apManager.Settings.GetValueForHighlLimitMin());

        }
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_HighLimitMaxShouldBeCorrect()
        {
            string highLimitMax = "$300.00";
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.AreEqual(highLimitMax, apManager.Settings.GetValueForHighlLimitMax());

        }
        //TURBO
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_TurboSectionPresents()
        {
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.IsTrue(apManager.Settings.TurboSectionPresents());
        }
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_TurboButtonsPresent()
        {
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.IsTrue(apManager.Settings.TurboButtonsPresent());
        }
        //CHOSE TABLE
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_ChoseTableSectionPresents()
        {
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.IsTrue(apManager.Settings.ChoseTableSectionIsPresented());
        }
        [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_ChoseTableButtonsPresent()
        {
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.IsTrue(apManager.Settings.ChoseTableButtonsPresent());
        }
        //SAVE
      //  [Test]
        public void When_SettingsPopupOpensAfterFirstStart_Expected_SaveButtonSholdCloseSettings()
        {
            apManager.Navigator.GoToHomeScreen_SettingsPopupAfterFirstStart(localisation);
            Assert.IsTrue(apManager.Settings.SettingPopupClosed_AfterStart() == false);
        }
    }
}
