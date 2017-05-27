namespace KinisiKaiLeitourgeia.Migrations
{
    using KinisiKaiLeitourgeia.Models.Dictionaries;
    using KinisiKaiLeitourgeia.Models.People;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KinisiKaiLeitourgeia.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "KinisiKaiLeitourgeia.Models.ApplicationDbContext";
        }

        protected override void Seed(KinisiKaiLeitourgeia.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //context.People.AddOrUpdate(
            //  p => new { p.Name, p.Surname },
            //  new Person { Name = "Andrew", Surname = "Peters" },
            //  new Person { Name = "Brice", Surname = "Lambson" },
            //  new Person { Name = "Rowan", Surname = "Miller" }
            //);

            //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT DoctorSpecialties ON");
            //context.DoctorSpecialties.AddOrUpdate(
            //  p => new { p.Id, p.Name },
            //  new DoctorSpecialty { Id = 1, Name = "asd" }
            //);
            //context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT DoctorSpecialties OFF");

        }
    }
}
