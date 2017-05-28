namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointmentPlace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "AppointmentPlaceId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Appointments", "AppointmentPlaceId");
            AddForeignKey("dbo.Appointments", "AppointmentPlaceId", "dbo.AppointmentPlaces", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "AppointmentPlaceId", "dbo.AppointmentPlaces");
            DropIndex("dbo.Appointments", new[] { "AppointmentPlaceId" });
            DropColumn("dbo.Appointments", "AppointmentPlaceId");
        }
    }
}
