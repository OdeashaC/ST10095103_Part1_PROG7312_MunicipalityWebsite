using System;
using System.Collections.Generic;

namespace ST10095103_Part1_PROG7312_MunicipalityWebsite.Models
{
    public partial class ReportIssue
    {
        public int IssueId { get; set; }

        public string IssueLocation { get; set; } = null!;

        public int? CategorySelectionId { get; set; }

        public string IssueDescription { get; set; } = null!;  

        public string? FilePath { get; set; }

        public string? FileType { get; set; }

        public DateOnly CreatedAt { get; set; }  

        public virtual CategorySelection? CategorySelection { get; set; }  
    }
}
