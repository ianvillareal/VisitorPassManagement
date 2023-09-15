using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor.Core
{
    public enum StatusType
    {
        [Display(Name = "In progress")]
        InProgress = 0,
        [Display(Name = "For approval")]
        ForApproval = 1,
        [Display(Name = "Pending approval")]
        Pending = 2,
        [Display(Name = "Approved")]
        Approved = 3,
        [Display(Name = "Declined")]
        Declined = 4,
        [Display(Name = "For Completion")]
        ForCompletion = 5,
        [Display(Name = "Completed")]
        Completed = 6
    }

    public enum PurposeType
    {
        [Display(Name = "Visit")]
        Visit,
        [Display(Name = "Construction")]
        Construction
    }

    public enum CategoryType
    {
        [Display(Name = "Applicant")]
        Applicant,
        [Display(Name = "Meeting")]
        Meeting,
        [Display(Name = "Site Visit")]
        SiteVisit,
        [Display(Name = "Inspection")]
        Inspection,
        [Display(Name = "Seminar")]
        Seminar,
        [Display(Name = "Construction")]
        Construction
    }
}