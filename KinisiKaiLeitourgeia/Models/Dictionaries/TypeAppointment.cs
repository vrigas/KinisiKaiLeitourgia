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
        [StringLength(50)]
        [Display(Name = "Είδος Ραντεβού")]
        public string Name { get; set; }
    }
}