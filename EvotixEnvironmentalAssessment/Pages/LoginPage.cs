using EvotixEnvironmentalAssessment.TestDriver;

namespace EvotixEnvironmentalAssessment.Pages
{
    public class LoginPage
    {
        public const string LOGIN_URL = "https://stirling.she-development.net/automation";
        public const string USERNAME_SELECTOR = "#username";
        public const string PASSWORD_SELECTOR = "#password";
        public const string LOGIN_BUTTON = "button#login";
        public const string LOGOUT_DIV = ".she-login-one-content";
        public const string LOGOUT_MESSAGE = "You are now logged out. Click here to return to the Assure application";

        public static void SetLoginCredentials(string user, string password)
        {
            Driver.FindElementByCss(USERNAME_SELECTOR).SendKeys(user);
            Driver.FindElementByCss(PASSWORD_SELECTOR).SendKeys(password);
        }

        public static void ClickLoginButton()
        {
            Driver.FindElementByCss(LOGIN_BUTTON).Click();
            Driver.WaitUntilElementPresentByCss(AssureHeader.USER_DROP_DOWN);
        }

        public static bool LogOutPageDisplayed()
        {
            var logout = Driver.FindElementByCss(LOGOUT_DIV);
            return logout.Displayed && logout.Text.Contains(LOGOUT_MESSAGE);
        }
    }
}
