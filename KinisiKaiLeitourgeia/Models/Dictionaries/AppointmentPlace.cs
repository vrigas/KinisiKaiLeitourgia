using KinisiKaiLeitourgeia.Models.Appointments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.Dictionaries
{
    public class AppointmentPlace
    {
        public byte Id { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Μέρος Ραντεβού")]
        public string Name { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }
    }
}