using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.People
{
    public class Therapist : Person
    {
        [Display(Name = "Αρ. Αδείας")]
        [StringLength(20)]
        public string LicenceNumber { get; set; }

        [StringLength(20)]
        public string AMKA { get; set; }
    }
}