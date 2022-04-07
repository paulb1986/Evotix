using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace EvotixEnvironmentalAssessment.TestDriver
{
    public static class DriverExtensions
    {
        public static IWebElement GetElementAfterWait(this IWebDriver driver, By by, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            try
            {
                return wait.Until(drive => drive.FindElement(by));
            }
            catch
            {
                return null;
            }
        }

        public static IList<IWebElement> GetElementsAfterWait(this IWebDriver driver, By by, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            try
            {
                return wait.Until(drive => drive.FindElements(by));
            }
            catch
            {
                return null;
            }
        }

        public static void WaitUntilElementDisplayed(this IWebDriver driver, By by, int timeout)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));

            try
            {
                wait.Until(drive => drive.FindElement(by).Displayed);
            }
            catch
            {
                throw new Exception("Expected element not displayed within acceptable time frame");
            }
        }
    }
}
