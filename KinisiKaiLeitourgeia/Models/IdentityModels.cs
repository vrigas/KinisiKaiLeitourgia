﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using KinisiKaiLeitourgeia.Models.People;
using KinisiKaiLeitourgeia.Models.Dictionaries;
using System.Data.Entity.ModelConfiguration.Conventions;
using KinisiKaiLeitourgeia.Models.Appointments;

namespace KinisiKaiLeitourgeia.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Person> People { get; set; }
        public DbSet<DoctorSpecialty> DoctorSpecialties{ get; set; }
        public DbSet<AppointmentPlace> AppointmentPlaces { get; set; }
        public DbSet<DoctorWorkplace> DoctorWorkplaces { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<TypeAppointment> TypeAppointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Therapist> Therapists { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}