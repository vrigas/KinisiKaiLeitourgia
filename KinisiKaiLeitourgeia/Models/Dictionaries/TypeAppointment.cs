using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.Dictionaries
{
    public class TypeAppointment
    {
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Είδος Ραντεβού")]
        [StringLength(50)]
        public string Name { get; set; }
    }
}