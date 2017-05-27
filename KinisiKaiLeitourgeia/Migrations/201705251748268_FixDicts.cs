namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDicts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppointmentPlaces", "Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.DoctorSpecialties", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DoctorSpecialties", "Name");
            DropColumn("dbo.AppointmentPlaces", "Name");
        }
    }
}
