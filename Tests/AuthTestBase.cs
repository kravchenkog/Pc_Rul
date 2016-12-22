using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PC_Rul_Tests
{
    public class AuthTestBase : TestBase
    {
        string localisation = "english";
        [SetUp]
        public void Setup_CloseSettingPopup()
        {
            apManager.Navigator.GoToHomeScreen(localisation);
            apManager.Auth.CloseSettings();
            apManager.Popup.ClosePopup();
            apManager.Popup.WaitUntilRoundHasBeenFinished();
            apManager.Auth.TapRebet();
            apManager.Table.ClearAllBets();
           

        }
    }
}
