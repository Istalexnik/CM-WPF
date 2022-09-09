using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace CM_WPF
{
    class Base
    {
       static IWebDriver driver;


        public static void startCreating(MainWindow mw)
        {
            try
            {
                createClaim(mw);
            }
            catch (Exception ex)
            {
                mw.Dispatcher.Invoke(() => { mw.screenBeforeRunning(); });
                Debug.WriteLine(ex.Message);
                if (ex.Message == "Thread was being aborted.")
                    killChromeProcess(1);
            }
            finally
            {
            }
        }

        public static void createClaim(MainWindow mw)
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(new List<string>() { "no-sandbox" });

            driver = new ChromeDriver(chromeDriverService, chromeOptions);
            driver.Url = "https://uat-app-vos47000000.geosolinc.com/vosnet/default.aspx";
            
            mw.Dispatcher.Invoke(() => { mw.screenAfterRunning(); });
            killChromeProcess(2);

        }

        public static void killChromeProcess(int driverOrBothDriverAndBrowser)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startinfo = new ProcessStartInfo();
            startinfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startinfo.FileName = "cmd.exe";
            startinfo.Arguments = "/C " + "taskkill /f /im chromedriver.exe";
            if(driverOrBothDriverAndBrowser == 2)
            {
                startinfo.Arguments = "/C " + "taskkill /f /im chrome.exe";
            }
            process.StartInfo = startinfo;
            process.Start();
        }


    }
}
