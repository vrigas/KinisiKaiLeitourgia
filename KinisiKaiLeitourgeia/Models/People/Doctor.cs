using KinisiKaiLeitourgeia.Models.Dictionaries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.People
{
    public class Doctor : Person
    {
        [Display(Name = "Ειδικότητα Ιατρού")]
        public byte DoctorSpecialtyId { get; set; }
        
        public DoctorSpecialty DoctorSpecialty { get; set; }

        [Display(Name = "Εργασιακός Φορέας")]
        public byte DoctorWorkplaceId { get; set; }

        public DoctorSpecialty DoctorWorkplace { get; set; }        
    }
}