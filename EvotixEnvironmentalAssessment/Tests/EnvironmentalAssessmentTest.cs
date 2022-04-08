using EvotixEnvironmentalAssessment.Helper;
using EvotixEnvironmentalAssessment.Models;
using EvotixEnvironmentalAssessment.Pages;
using EvotixEnvironmentalAssessment.TestDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EvotixEnvironmentalAssessment
{
    [TestClass]
    public class EnvironmentalAssessmentTest
    {
        readonly User TestUser = User.TestUser;

        [TestInitialize]
        public void TestInit()
        {
            Driver.InitialiseBrowser();
            LoginHelper.LoginAsUser(TestUser);
        }

        [TestMethod]
        public void Add_And_Delete_New_Record()
        {
            var testRecordOne = EnvironmentalRecord.TestRecord();
            var testRecordTwo = EnvironmentalRecord.TestRecord();

            AssureHeaderHelper.GoToEnvironAssessmentViaModulesDDL();

            EnvironmentPage.ClickNewRecordButton();
            CreateRecordHelper.SetEnvironmentRecordDetailsAndSave(testRecordOne);

            EnvironmentPage.ClickNewRecordButton();
            CreateRecordHelper.SetEnvironmentRecordDetailsAndSave(testRecordTwo);

            //remove comments below

            //Assert both records are have been added to list

            //Delete record one 

            //Assert record one is not present
            //Assert record two is still present 
        }

        [TestCleanup]
        public void Cleanup()
        {
            LoginHelper.Logout();
            Driver.Close();
        }
    }
}
