using EvotixEnvironmentalAssessment.TestDriver;
using OpenQA.Selenium;

namespace EvotixEnvironmentalAssessment.Pages

{
    public class CreateRecordPage
    {
        public const string SAVE_BUTTON = "button[value='Continue']";
        public const string SAVE_AND_CLOSE_BUTTON = "button[value='Close']";
        public const string DESC_TEXT_AREA = "textarea[id*='_Description']";
        public const string DATE_INPUT = "input[id*='_AssessmentDate']";

        public static void SetEnvironmentalDetails(string selector, string value)
        {
            Driver.FindElementByCss(selector).SendKeys(value + Keys.Tab);
        }

        public static void ClickSaveAndCloseButton()
        {
            Driver.FindElementByCss(SAVE_AND_CLOSE_BUTTON).Click();
            Driver.WaitUntilElementPresentByCss(EnvironmentPage.NEW_RECORD_BTN_SELECTOR);
        }
    }
}
