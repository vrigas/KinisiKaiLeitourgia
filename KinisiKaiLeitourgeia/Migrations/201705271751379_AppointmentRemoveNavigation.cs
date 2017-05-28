namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentRemoveNavigation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "AppointmentPlace_Id", "dbo.AppointmentPlaces");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.People");
            DropForeignKey("dbo.Appointments", "TherapistId", "dbo.People");
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropIndex("dbo.Appointments", new[] { "TherapistId" });
            DropIndex("dbo.Appointments", new[] { "AppointmentPlace_Id" });
            DropColumn("dbo.Appointments", "AppointmentPlace_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "AppointmentPlace_Id", c => c.Byte());
            CreateIndex("dbo.Appointments", "AppointmentPlace_Id");
            CreateIndex("dbo.Appointments", "TherapistId");
            CreateIndex("dbo.Appointments", "PatientId");
            AddForeignKey("dbo.Appointments", "TherapistId", "dbo.People", "Id");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.People", "Id");
            AddForeignKey("dbo.Appointments", "AppointmentPlace_Id", "dbo.AppointmentPlaces", "Id");
        }
    }
}
