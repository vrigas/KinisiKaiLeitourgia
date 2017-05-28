using KinisiKaiLeitourgeia.Models.Appointments;
using KinisiKaiLeitourgeia.Models.Dictionaries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.People
{
    public class Patient : Person
    {
        [Display(Name = "Θεράπων Ιατρός")]
        public int? CurrentDoctorId { get; set; }
        
        public Doctor CurrentDoctor { get; set; }

        [Display(Name = "Παραπέμπων Ιατρός")]
        public int? ReferrerDoctorId { get; set; }

        public Doctor ReferrerDoctor { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ημ/νία Γέννησης")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Παραπέμπων Ιατρός")]
        public byte? InsuranceID { get; set; }

        public Insurance Insurance { get; set; }

        public IEnumerable<Parent> Parent { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

    }
}