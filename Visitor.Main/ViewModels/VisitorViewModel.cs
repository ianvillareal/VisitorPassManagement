using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Visitor.Main.ViewModels
{
    public class VisitorViewModel
    {
        public long VisitorId { get; set; }
        public long RequestId { get; set; }
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        public string Occupation { get; set; }
        [Display(Name = "Email address")]
        public string EmailAddress { get; set; }
        public string CurriculumVitae { get; set; }
        public bool ForAddition { get; set; }
        public int Index { get; set; }

        public string FullName
        {
            get
            {
                return string.Concat(this.FirstName, ' ', this.MiddleName, ' ', this.LastName);
            }
        }
    }
}