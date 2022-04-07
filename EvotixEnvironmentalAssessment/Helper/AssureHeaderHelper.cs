using EvotixEnvironmentalAssessment.Pages;
using EvotixEnvironmentalAssessment.TestDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvotixEnvironmentalAssessment.Helper
{
    public class AssureHeaderHelper
    {
        public static void GoToEnvironAssessmentViaModulesDDL()
        {
            AssureHeader.ExpandModulesDropdown();
            AssureHeader.MoveToModulesOption(AssureHeader.ENVIRONMENT_TEXT);
            AssureHeader.MoveToModulesOption(AssureHeader.ENVIRONMENTAL_ASSESSMENT_TEXT, true);
            Driver.WaitUntilElementPresentByCss(EnvironmentPage.CURRENTLY_SELECTED_MODULE);
            Assert.IsTrue(EnvironmentPage.IsOnCorrectEnvironmentPageTab(EnvironmentPage.ENVIRONMENTAL_ASSESSMENT),
                $"Not on : {EnvironmentPage.ENVIRONMENTAL_ASSESSMENT} tab");
        }
    }
}
