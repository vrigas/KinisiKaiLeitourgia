namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentSetup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "TherapistId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "AppointmentPlaceId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Appointments", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Appointments", "AppointmentPlace_Id", c => c.Byte());
            CreateIndex("dbo.Appointments", "PatientId");
            CreateIndex("dbo.Appointments", "TherapistId");
            CreateIndex("dbo.Appointments", "AppointmentPlace_Id");
            AddForeignKey("dbo.Appointments", "AppointmentPlace_Id", "dbo.AppointmentPlaces", "Id");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.People", "Id");
            AddForeignKey("dbo.Appointments", "TherapistId", "dbo.People", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "TherapistId", "dbo.People");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.People");
            DropForeignKey("dbo.Appointments", "AppointmentPlace_Id", "dbo.AppointmentPlaces");
            DropIndex("dbo.Appointments", new[] { "AppointmentPlace_Id" });
            DropIndex("dbo.Appointments", new[] { "TherapistId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
            DropColumn("dbo.Appointments", "AppointmentPlace_Id");
            DropColumn("dbo.Appointments", "Balance");
            DropColumn("dbo.Appointments", "Price");
            DropColumn("dbo.Appointments", "AppointmentPlaceId");
            DropColumn("dbo.Appointments", "TherapistId");
            DropColumn("dbo.Appointments", "PatientId");
        }
    }
}
