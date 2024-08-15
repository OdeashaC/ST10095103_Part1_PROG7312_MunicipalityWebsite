using System;
using System.Collections.Generic;

namespace ST10095103_Part1_PROG7312_MunicipalityWebsite.Models;

public partial class CategorySelection
{
    public int CategorySelectionId { get; set; }

    public string? Categories { get; set; }

    public virtual ICollection<ReportIssue> ReportIssues { get; set; } = new List<ReportIssue>();
}
