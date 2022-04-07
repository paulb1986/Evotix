using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EvotixEnvironmentalAssessment.TestDriver
{
    public static class Driver
    {
        private const int DEFAULT_TIMEOUT_SECONDS = 3;

        public static IWebDriver Instance { get; set; }

        public static void InitialiseBrowser()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            Instance = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, chromeOptions);
            Instance.Manage().Cookies.DeleteAllCookies();

            if (Instance == null)
            {
                throw new Exception("Driver not created");
            }

            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DEFAULT_TIMEOUT_SECONDS);
        }

        public static void NavigateToUrl(string url)
        {
            Instance.Navigate().GoToUrl(url);
        }

        public static void Wait(int waitMilliseconds = 1000)
        {
            Thread.Sleep(waitMilliseconds);
        }

        public static void Close()
        {
            Instance.Dispose();
        }

        public static IWebElement FindElementByCss(string cssSelector, int timeout = DEFAULT_TIMEOUT_SECONDS)
        {
            return Instance.GetElementAfterWait(By.CssSelector(cssSelector), timeout);
        }

        public static IList<IWebElement> FindElementsByCss(string cssSelector, int timeout = DEFAULT_TIMEOUT_SECONDS)
        {
            return Instance.GetElementsAfterWait(By.CssSelector(cssSelector), timeout);
        }

        public static void WaitUntilElementPresentByCss(string cssSelector, int timeout = DEFAULT_TIMEOUT_SECONDS)
        {
            Instance.WaitUntilElementDisplayed(By.CssSelector(cssSelector), timeout);
        }
    }
}

