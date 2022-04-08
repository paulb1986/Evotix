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
            //Initialise browser and login user provider credentials
            Driver.InitialiseBrowser();
            LoginHelper.LoginAsUser(TestUser);
        }

        [TestMethod]
        public void Add_And_Delete_New_Record()
        {
            //Set up record data
            var testRecordOneDetails = EnvironmentalRecord.TestRecord();
            var testRecordTwoDetails = EnvironmentalRecord.TestRecord();

            AssureHeaderHelper.GoToEnvironAssessmentViaModulesDDL();

            //Add new records
            EnvironmentPage.ClickNewRecordButton();
            CreateRecordHelper.SetEnvironmentRecordDetailsAndSave(testRecordOneDetails);

            EnvironmentPage.ClickNewRecordButton();
            CreateRecordHelper.SetEnvironmentRecordDetailsAndSave(testRecordTwoDetails);

            //Find newly created records from list
            var createdRecordOne = EnvironmentPage.GetEnvironmentRecordByDescription(testRecordOneDetails.description);
            var createdRecordTwo = EnvironmentPage.GetEnvironmentRecordByDescription(testRecordTwoDetails.description);

            //Verify newly created records are present and details are as expected
            EnvironmentRecordHelper.RecordPresentAndDetailsCorrect(testRecordOneDetails, createdRecordOne);
            EnvironmentRecordHelper.RecordPresentAndDetailsCorrect(testRecordTwoDetails, createdRecordTwo);

            //Store pre delete record count
            var recordCount = EnvironmentPage.EnvironmentRecordCount();

            //Delete first created record
            EnvironmentRecordHelper.DeleteRecord(createdRecordOne);

            //Verify first created record is deleted, second created record is still present and count is as expected
            Assert.IsTrue(EnvironmentPage.EnvironmentRecordCount() == recordCount - 1,
                "Unexpected number of records after record delete");

            Assert.IsNull(EnvironmentPage.GetEnvironmentRecordByDescription(testRecordOneDetails.description),
                "CreatedRecordOne is still present in list");

            Assert.IsNotNull(EnvironmentPage.GetEnvironmentRecordByDescription(testRecordTwoDetails.description),
                "CreatedRecordTwo not present in list");
        }

        [TestCleanup]
        public void Cleanup()
        {
            LoginHelper.Logout();
            Driver.Close();
        }
    }
}
