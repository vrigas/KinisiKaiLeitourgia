namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        TaskID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        IsAllDay = c.Boolean(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        StartTimezone = c.String(),
                        EndTimezone = c.String(),
                        RecurrenceRule = c.String(),
                        RecurrenceException = c.String(),
                    })
                .PrimaryKey(t => t.TaskID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Appointments");
        }
    }
}
