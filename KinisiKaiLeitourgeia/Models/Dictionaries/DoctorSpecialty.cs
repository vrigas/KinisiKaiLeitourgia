using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.Dictionaries
{
    public class DoctorSpecialty
    {
        public int Id;

        [Required]
        [StringLength(50)]
        [Display(Name = "Ειδικότιτα Ιατρού")]
        public string Name;
    }
}