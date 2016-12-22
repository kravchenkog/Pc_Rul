using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace PC_Rul_Tests
{
    public class ApplicationManager
    {
        private WebDriverWait wait;
        protected IWebDriver driver;
        protected string baseURL;
        protected LimitsData limitsData;
        protected ButtonsHelper buttons;
        protected NavigationHelper navigator;
        protected SettingsHelper settings;
        protected AuthHelper auth;
        protected TableHelper table;
        protected PopupHelper popup;
        protected CellHelper cell;
        
        
        protected static ThreadLocal<ApplicationManager> apManager = new ThreadLocal<ApplicationManager>();



        public ApplicationManager()
        {
            
            EnvironmentData baseURL = new EnvironmentData()
            {
                English = "http://192.168.12.3/Html5GamesForGGPMock/130008/Game/?gameData=%7b%22integration%22%3a1%2c%22gameId%22%3a710%2c%22token%22%3a%221234567%22%2c%22url%22%3a%22%2fmobile%2fdefault.aspx%22%2c%22jointype%22%3a1%2c%22operatorid%22%3a0%2c%22lang%22%3a%22eng%22%2c%22gametype%22%3a130008%2c%22gamecurrencycode%22%3a%22USD%22%2c%22balance%22%3a799439925%2c%22operatorxml%22%3a%7b%22_888ClientData%22%3a%7b%22ClientVersion%22%3a%22Touch-0-EN-0-1.0-0-0%22%2c%22ClientPlatform%22%3a700%2c%22ClientURL%22%3a%22url%22%2c%22BrandID%22%3a0%2c%22SubBrandID%22%3a0%2c%22ProductPackage%22%3a37%2c%22ClientType%22%3a14%2c%22GameLimits%22%3a-1%2c%22EnableOperatorData%22%3atrue%2c%22IsFreePlay%22%3a0%2c%22RequestedGameLimit%22%3a-1%2c%22RequestedTimeLimit%22%3a0%2c%22RestrictionPeriod%22%3a0%2c%22IntervalReminderInMinutes%22%3a0%7d%7d%2c%22gameName%22%3a%22European+Roulette%22%2c%22GameProviderType%22%3a3%2c%22regulationTypeID%22%3a0%2c%22isHybrid%22%3afalse%7d"
            };
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            //driver.Navigate().GoToUrl(baseURL.English);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            buttons = new ButtonsHelper(this, baseURL);
            navigator = new NavigationHelper(this, baseURL);
            settings = new SettingsHelper(this, baseURL);
            auth = new AuthHelper(this);
            table = new TableHelper(this);
            popup = new PopupHelper(this);
            cell = new CellHelper(this);
            
        }
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public AuthHelper Auth
        {
            get
            {
                return auth;
            }
        }
        public CellHelper Cell
        {
            get
            {
                return cell;
            }
        }
        public PopupHelper Popup
        {
            get
            {
                return popup;
            }
        }
        public TableHelper Table
        {
            get
            {
                return table;
            }
        }
        public ButtonsHelper Buttons
        {
            get
            {
                return buttons;
            }
        }
        public NavigationHelper Navigator
        {
            get
            {
                return navigator;
            }
        }
        public SettingsHelper Settings
        {
            get
            {
                return settings;
            }
        }

        public static ApplicationManager GetInstance()
        {
            
            if (!apManager.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                
                apManager.Value = newInstance;
            }
            return apManager.Value;
        }


    }
}
