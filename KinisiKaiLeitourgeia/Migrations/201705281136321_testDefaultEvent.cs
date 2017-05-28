namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testDefaultEvent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "PatientId");
            DropColumn("dbo.Appointments", "TherapistId");
            DropColumn("dbo.Appointments", "AppointmentPlaceId");
            DropColumn("dbo.Appointments", "Price");
            DropColumn("dbo.Appointments", "Balance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Appointments", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Appointments", "AppointmentPlaceId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "TherapistId", c => c.Int(nullable: false));
            AddColumn("dbo.Appointments", "PatientId", c => c.Int(nullable: false));
        }
    }
}
