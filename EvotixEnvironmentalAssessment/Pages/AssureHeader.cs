using EvotixEnvironmentalAssessment.TestDriver;
using OpenQA.Selenium.Interactions;
using System.Linq;

namespace EvotixEnvironmentalAssessment.Pages
{
    public class AssureHeader
    {
        public const string USER_DROP_DOWN = ".nav-user-name";
        public const string USER_DROP_DOWN_EXPANDED = ".she-user-info .she-dropdown-open";
        public const string LOGOUT_OPTION = "Log Out";
        public const string DDL_SELECTOR = ".she-has-submenu";
        public const string DDL_EXPANDED_SELECTOR = ".she-dropdown-open";
        public const string DDL_OPTION_SELECTOR = "li a";
        public const string MODULES_TEXT = "Modules";
        public const string ENVIRONMENT_TEXT = "Environment";
        public const string ENVIRONMENTAL_ASSESSMENT_TEXT = "Environmental Assessment";


        public static string GetUserDropdownText()
        {
            return Driver.FindElementByCss(USER_DROP_DOWN).Text;
        }

        public static void ExpandUserDropdown()
        {
            Driver.FindElementByCss(USER_DROP_DOWN).Click();
            Driver.WaitUntilElementPresentByCss(USER_DROP_DOWN_EXPANDED);
        }

        public static void ClickUserDropdownOption(string option)
        {
            var options = Driver.FindElementsByCss($"{USER_DROP_DOWN_EXPANDED} li");
            options.First(li => li.Text.Contains(option)).Click();
        }

        public static void ExpandModulesDropdown()
        {
            Driver.FindElementsByCss(DDL_SELECTOR).First(ddl => ddl.Text == MODULES_TEXT).Click();
            Driver.WaitUntilElementPresentByCss($"{DDL_SELECTOR}{DDL_EXPANDED_SELECTOR}");
        }

        public static void MoveToModulesOption(string optionText, bool clickOption = false)
        {
            var modulesOption = Driver.FindElementsByCss(DDL_OPTION_SELECTOR).First(option => option.Text == optionText);

            Actions move = new Actions(Driver.Instance);
            move.MoveToElement(modulesOption);

            if (clickOption)
            {
                move.Click();
            }

            move.Build().Perform();
        }
    }
}
