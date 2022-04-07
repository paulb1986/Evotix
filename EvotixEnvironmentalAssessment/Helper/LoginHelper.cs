using EvotixEnvironmentalAssessment.Models;
using EvotixEnvironmentalAssessment.Pages;
using EvotixEnvironmentalAssessment.TestDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvotixEnvironmentalAssessment.Helper
{
    public class LoginHelper
    {
        public static void LoginAsUser(User user)
        {
            Driver.NavigateToUrl(LoginPage.LOGIN_URL);
            Driver.WaitUntilElementPresentByCss(LoginPage.LOGIN_BUTTON);
            LoginPage.SetLoginCredentials(user.username, user.password);
            LoginPage.ClickLoginButton();
            Assert.AreEqual($"{user.firstname} {user.lastname}", AssureHeader.GetUserDropdownText(),
                "Unexpected user name displayed on Assure header");
        }

        public static void Logout()
        {
            AssureHeader.ExpandUserDropdown();
            AssureHeader.ClickUserDropdownOption(AssureHeader.LOGOUT_OPTION);
            Driver.WaitUntilElementPresentByCss(LoginPage.LOGOUT_DIV);
            Assert.IsTrue(LoginPage.LogOutPageDisplayed(), "Logout page not displayed");
        }
    }
}
