namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeAppointment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "TypeAppointmentId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Appointments", "TypeAppointmentId");
            AddForeignKey("dbo.Appointments", "TypeAppointmentId", "dbo.TypeAppointments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "TypeAppointmentId", "dbo.TypeAppointments");
            DropIndex("dbo.Appointments", new[] { "TypeAppointmentId" });
            DropColumn("dbo.Appointments", "TypeAppointmentId");
        }
    }
}
