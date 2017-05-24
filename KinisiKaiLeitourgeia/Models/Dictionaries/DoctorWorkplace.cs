using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.Dictionaries
{
    public class DoctorWorkplace
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Εργασιακός Φορέας")]
        [StringLength(50)]
        public string name { get; set; }
    }
}