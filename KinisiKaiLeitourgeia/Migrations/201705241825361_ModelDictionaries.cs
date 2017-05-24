namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelDictionaries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppointmentPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorSpecialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DoctorWorkplaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Insurances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TypeAppointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.People", "Telephone", c => c.String());
            AddColumn("dbo.People", "Workphone", c => c.String());
            AddColumn("dbo.People", "Mobile", c => c.String());
            AddColumn("dbo.People", "Email", c => c.String());
            AddColumn("dbo.People", "Address", c => c.String());
            AddColumn("dbo.People", "Info", c => c.String());
            AddColumn("dbo.People", "CurrentDoctor", c => c.Int());
            AddColumn("dbo.People", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.People", "Surname", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false));
            DropColumn("dbo.People", "Discriminator");
            DropColumn("dbo.People", "CurrentDoctor");
            DropColumn("dbo.People", "Info");
            DropColumn("dbo.People", "Address");
            DropColumn("dbo.People", "Email");
            DropColumn("dbo.People", "Mobile");
            DropColumn("dbo.People", "Workphone");
            DropColumn("dbo.People", "Telephone");
            DropTable("dbo.TypeAppointments");
            DropTable("dbo.Insurances");
            DropTable("dbo.DoctorWorkplaces");
            DropTable("dbo.DoctorSpecialties");
            DropTable("dbo.AppointmentPlaces");
        }
    }
}
