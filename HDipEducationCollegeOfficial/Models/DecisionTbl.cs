using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HDipEducationCollegeOfficial.Models
{
	public class DecisionTbl
	{
		[Display(Name = "Student ID")]
		public int ApplicationID { get; set; }

		[Display(Name = "PPS Number")]
		public string PPSNumber { get; set; }

        [Display(Name = "Decision")]
        public bool Decision {  get; set; }
    }
}