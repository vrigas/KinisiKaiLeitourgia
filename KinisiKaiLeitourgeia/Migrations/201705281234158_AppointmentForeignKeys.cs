namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentForeignKeys : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Appointments", "PatientId");
            CreateIndex("dbo.Appointments", "TherapistId");
            AddForeignKey("dbo.Appointments", "PatientId", "dbo.People", "Id");
            AddForeignKey("dbo.Appointments", "TherapistId", "dbo.People", "Id");
            DropColumn("dbo.Appointments", "AppointmentPlaceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "AppointmentPlaceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Appointments", "TherapistId", "dbo.People");
            DropForeignKey("dbo.Appointments", "PatientId", "dbo.People");
            DropIndex("dbo.Appointments", new[] { "TherapistId" });
            DropIndex("dbo.Appointments", new[] { "PatientId" });
        }
    }
}
