using EvotixEnvironmentalAssessment.Models;
using EvotixEnvironmentalAssessment.Pages;
using EvotixEnvironmentalAssessment.TestDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace EvotixEnvironmentalAssessment.Helper
{
    public class EnvironmentRecordHelper
    {
        public static void RecordPresentAndDetailsCorrect(EnvironmentalRecord expected, IWebElement actual)
        {
            Assert.IsNotNull(actual, "Could not verify record present in list");

            Assert.IsTrue(EnvironmentPage.EnvironmentRecordDetailsCorrect
                (actual, EnvironmentPage.ASSESSMENT_DATE, expected.date), "Record assessment date incorrect");

            Assert.IsTrue(EnvironmentPage.EnvironmentRecordDetailsCorrect
                (actual, EnvironmentPage.DESCRIPTION, expected.description), "Record description incorrect");
        }

        public static void DeleteRecord(IWebElement record)
        {
            EnvironmentPage.ClickDeleteRecordButton(record);
            EnvironmentPage.ClickDeleteDialogButton(EnvironmentPage.CONFIRM_TEXT);
            Driver.Wait(2000);
        }
    }
}
