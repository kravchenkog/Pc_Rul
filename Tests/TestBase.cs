using System.Threading;
using NUnit.Framework;
using System;
using System.Text;

namespace PC_Rul_Tests
{
    public class TestBase
    {
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected ApplicationManager apManager;
        

        [SetUp]
        public void SetupApplicationManager()
        {
            
            apManager = ApplicationManager.GetInstance();

        }

    }
}
