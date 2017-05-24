﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.People
{
    public class Parent : Person
    {
        [Required]
        [Display(Name = "Ασθενής")]
        [ForeignKey("Patient")]
        public int PatientID { get; set; }

        public Patient Patient { get; set; }
    }
}