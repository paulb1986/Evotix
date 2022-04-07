using System;

namespace EvotixEnvironmentalAssessment.Models
{
    public class EnvironmentalRecord
    {
        public string description { get; set; }
        public string date { get; set; }

        public static EnvironmentalRecord TestRecord() => new EnvironmentalRecord()
        {
            description = $"{Guid.NewGuid()}",
            date = DateTime.Now.ToString("dd/MM/yyyy")
        };
    }
}
