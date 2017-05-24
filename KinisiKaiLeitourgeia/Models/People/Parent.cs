using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.People
{
    public class Parent : Person
    {
        [Display(Name = "Ασθενής")]
        public int PatientID { get; set; }

        public Patient Patient { get; set; }
    }
}