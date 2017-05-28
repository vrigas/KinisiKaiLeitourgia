using KinisiKaiLeitourgeia.Models.Appointments;
using KinisiKaiLeitourgeia.Models.Dictionaries;
using KinisiKaiLeitourgeia.Models.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KinisiKaiLeitourgeia.ViewModels
{
    public class SchedulerViewModel
    {
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<Therapist> Therapists { get; set; }
        public IEnumerable<AppointmentPlace> AppointmentPlaces{ get; set; }
        public Appointment Appointment { get; set; }
    }
}