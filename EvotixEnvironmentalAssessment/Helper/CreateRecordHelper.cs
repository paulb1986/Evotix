using EvotixEnvironmentalAssessment.Models;
using EvotixEnvironmentalAssessment.Pages;

namespace EvotixEnvironmentalAssessment.Helper
{
    public class CreateRecordHelper
    {
        public static void SetEnvironmentRecordDetailsAndSave(EnvironmentalRecord record)
        {
            CreateRecordPage.SetEnvironmentalDetails(CreateRecordPage.DESC_TEXT_AREA, record.description);
            CreateRecordPage.SetEnvironmentalDetails(CreateRecordPage.DATE_INPUT, record.date);
            CreateRecordPage.ClickSaveAndCloseButton();
        }
    }
}
