using System.Collections.Generic;

namespace ST10095103_Part1_PROG7312_MunicipalityWebsite.Models
{
    public class ReportIssueViewModel
    {
        public ReportIssue ReportIssue { get; set; }
        public IEnumerable<CategorySelection> Categories { get; set; } // This should be a list or enumerable
    }

}
