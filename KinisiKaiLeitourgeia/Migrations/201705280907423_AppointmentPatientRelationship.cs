namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppointmentPatientRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "Patient_Id", c => c.Int());
            CreateIndex("dbo.Appointments", "Patient_Id");
            AddForeignKey("dbo.Appointments", "Patient_Id", "dbo.People", "Id");
            DropColumn("dbo.Appointments", "PatientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.People");
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            DropColumn("dbo.Appointments", "Patient_Id");
        }
    }
}
