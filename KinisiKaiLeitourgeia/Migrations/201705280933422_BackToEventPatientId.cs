namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BackToEventPatientId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appointments", "Patient_Id", "dbo.People");
            DropIndex("dbo.Appointments", new[] { "Patient_Id" });
            AddColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
            DropColumn("dbo.Appointments", "Patient_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Patient_Id", c => c.Int());
            DropColumn("dbo.Appointments", "PatientId");
            CreateIndex("dbo.Appointments", "Patient_Id");
            AddForeignKey("dbo.Appointments", "Patient_Id", "dbo.People", "Id");
        }
    }
}
