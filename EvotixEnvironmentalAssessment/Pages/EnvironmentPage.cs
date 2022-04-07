using EvotixEnvironmentalAssessment.TestDriver;

namespace EvotixEnvironmentalAssessment.Pages
{
    public class EnvironmentPage
    {
        public const string BREAD_CRUMB_SELECTOR = ".breadcrumb";
        public const string CURRENTLY_SELECTED_MODULE = "a.module.current";
        public const string ENVIRONMENTAL_ASSESSMENT = "Environmental Assessment";
        public const string ENVIRONMENTAL_ASSESS_BREADCRUMB = "Home > Environment > Environmental Assessment";
        public const string NEW_RECORD_BTN_SELECTOR = "a.create_record";

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
    }
}
