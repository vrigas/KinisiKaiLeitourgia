using Kendo.Mvc.UI;
using KinisiKaiLeitourgeia.Models.Dictionaries;
using KinisiKaiLeitourgeia.Models.People;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.Models.Appointments
{
    public class Appointment : ISchedulerEvent
    {
        [Key]
        public int TaskID { get; set; }

        [Display(Name = "Τίτλος")]
        public string Title { get; set; }

        [Display(Name = "Περιγραφή")]
        public string Description { get; set; }

        [Display(Name = "Ολοήμερο")]
        public bool IsAllDay { get; set; }

        [Display(Name = "Από")]
        public DateTime Start { get; set; }

        [Display(Name = "Έως")]
        public DateTime End { get; set; }
        
        [Display(Name = "Ασθενής")]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [Display(Name = "Θεραπευτής")]
        public int TherapistId { get; set; }

        public Therapist Therapist { get; set; }

        [Display(Name = "Μέρος Ραντεβού")]
        public int AppointmentPlaceId { get; set; }

        public AppointmentPlace AppointmentPlace { get; set; }

        [Display(Name = "Τιμή")]
        public decimal Price { get; set; }

        [Display(Name = "Υπόλοιπο")]
        public decimal Balance { get; set; }

        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }


    }
}