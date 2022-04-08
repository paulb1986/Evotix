using EvotixEnvironmentalAssessment.TestDriver;
using OpenQA.Selenium;
using System.Linq;

namespace EvotixEnvironmentalAssessment.Pages
{
    public class EnvironmentPage
    {
        public const string BREAD_CRUMB_SELECTOR = ".breadcrumb";
        public const string CURRENTLY_SELECTED_MODULE = "a.module.current";
        public const string ENVIRONMENTAL_ASSESSMENT = "Environmental Assessment";
        public const string ENVIRONMENTAL_ASSESS_BREADCRUMB = "Home > Environment > Environmental Assessment";
        public const string NEW_RECORD_BTN_SELECTOR = "a.create_record";
        public const string RECORD_ROW_SELECTOR = ".list_layout";
        public const int STRING_ELLIPSIS_COUNT = 25;
        public const string ASSESSMENT_DATE = "Assessment Date:";
        public const string DESCRIPTION = "Description:";
        public const string MANAGE_BUTTON = "button[id*=manageRecord]";
        public const string DELETE = "a[id*=cogDelete]";
        public const string DELETE_DIALOG = "[aria-describedby='deleteDialog']";
        public const string CONFIRM_TEXT = "Confirm";

        public static bool IsOnCorrectEnvironmentPageTab(string tab)
        {
            return Driver.FindElementByCss(BREAD_CRUMB_SELECTOR).Text.Contains(tab) &&
                Driver.FindElementByCss(CURRENTLY_SELECTED_MODULE).Text == tab;
        }

        public static void ClickNewRecordButton()
        {
            Driver.FindElementByCss(NEW_RECORD_BTN_SELECTOR).Click();
            Driver.WaitUntilElementPresentByCss(CreateRecordPage.SAVE_BUTTON);
        }

        public static int EnvironmentRecordCount()
        {
            return Driver.FindElementsByCss(RECORD_ROW_SELECTOR).Count();
        }

        public static IWebElement GetEnvironmentRecordByDescription(string desc)
        {
            return Driver.FindElementsByCss(RECORD_ROW_SELECTOR)
           .FirstOrDefault(record => record.Text.Contains(desc.Substring(0, STRING_ELLIPSIS_COUNT)));
        }

        public static bool EnvironmentRecordDetailsCorrect(IWebElement record, string selector, string value)
        {
            if (value.Length > STRING_ELLIPSIS_COUNT)
            {
                value = value.Substring(0, STRING_ELLIPSIS_COUNT);
            }

            var recordProperty = record.FindElements(By.CssSelector("li"))
                .First(x => x.FindElement(By.CssSelector("span")).Text == selector);

            return recordProperty.FindElement(By.CssSelector("li a")).Text.Contains(value);
        }

        public static void ClickDeleteRecordButton(IWebElement record)
        {
            record.FindElement(By.CssSelector(MANAGE_BUTTON)).Click();
            Driver.Wait();
            record.FindElement(By.CssSelector(DELETE)).Click();
            Driver.WaitUntilElementPresentByCss(DELETE_DIALOG);
        }

        public static void ClickDeleteDialogButton(string buttonText)
        {
            Driver.FindElementsByCss($"{DELETE_DIALOG} [type ='button']")
                .First(btn => btn.Text == buttonText).Click();

            Driver.WaitUntilElementPresentByCss(NEW_RECORD_BTN_SELECTOR);
        }
    }
}
