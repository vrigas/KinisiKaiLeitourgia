namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class People : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.AppointmentPlaces");
            DropPrimaryKey("dbo.DoctorSpecialties");
            DropPrimaryKey("dbo.DoctorWorkplaces");
            DropPrimaryKey("dbo.Insurances");
            DropPrimaryKey("dbo.TypeAppointments");
            AddColumn("dbo.People", "DoctorWorkplaceId", c => c.Byte());
            AddColumn("dbo.People", "PatientID", c => c.Int());
            AddColumn("dbo.People", "CurrentDoctorId", c => c.Int());
            AddColumn("dbo.People", "ReferrerDoctorId", c => c.Int());
            AddColumn("dbo.People", "Birthdate", c => c.DateTime());
            AddColumn("dbo.People", "InsuranceID", c => c.Byte());
            AddColumn("dbo.People", "ParentId", c => c.Int());
            AddColumn("dbo.People", "LicenceNumber", c => c.String(maxLength: 20));
            AddColumn("dbo.People", "AMKA", c => c.String(maxLength: 20));
            AlterColumn("dbo.AppointmentPlaces", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.DoctorSpecialties", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.DoctorWorkplaces", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Insurances", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.TypeAppointments", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.AppointmentPlaces", "Id");
            AddPrimaryKey("dbo.DoctorSpecialties", "Id");
            AddPrimaryKey("dbo.DoctorWorkplaces", "Id");
            AddPrimaryKey("dbo.Insurances", "Id");
            AddPrimaryKey("dbo.TypeAppointments", "Id");
            CreateIndex("dbo.People", "DoctorWorkplaceId");
            CreateIndex("dbo.People", "PatientID");
            CreateIndex("dbo.People", "CurrentDoctorId");
            CreateIndex("dbo.People", "ReferrerDoctorId");
            CreateIndex("dbo.People", "InsuranceID");
            AddForeignKey("dbo.People", "DoctorWorkplaceId", "dbo.DoctorSpecialties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.People", "CurrentDoctorId", "dbo.People", "Id");
            AddForeignKey("dbo.People", "InsuranceID", "dbo.Insurances", "Id", cascadeDelete: true);
            AddForeignKey("dbo.People", "ReferrerDoctorId", "dbo.People", "Id");
            AddForeignKey("dbo.People", "PatientID", "dbo.People", "Id");
            DropColumn("dbo.People", "CurrentDoctor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "CurrentDoctor", c => c.Int());
            DropForeignKey("dbo.People", "PatientID", "dbo.People");
            DropForeignKey("dbo.People", "ReferrerDoctorId", "dbo.People");
            DropForeignKey("dbo.People", "InsuranceID", "dbo.Insurances");
            DropForeignKey("dbo.People", "CurrentDoctorId", "dbo.People");
            DropForeignKey("dbo.People", "DoctorWorkplaceId", "dbo.DoctorSpecialties");
            DropIndex("dbo.People", new[] { "InsuranceID" });
            DropIndex("dbo.People", new[] { "ReferrerDoctorId" });
            DropIndex("dbo.People", new[] { "CurrentDoctorId" });
            DropIndex("dbo.People", new[] { "PatientID" });
            DropIndex("dbo.People", new[] { "DoctorWorkplaceId" });
            DropPrimaryKey("dbo.TypeAppointments");
            DropPrimaryKey("dbo.Insurances");
            DropPrimaryKey("dbo.DoctorWorkplaces");
            DropPrimaryKey("dbo.DoctorSpecialties");
            DropPrimaryKey("dbo.AppointmentPlaces");
            AlterColumn("dbo.TypeAppointments", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Insurances", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DoctorWorkplaces", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.DoctorSpecialties", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AppointmentPlaces", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.People", "AMKA");
            DropColumn("dbo.People", "LicenceNumber");
            DropColumn("dbo.People", "ParentId");
            DropColumn("dbo.People", "InsuranceID");
            DropColumn("dbo.People", "Birthdate");
            DropColumn("dbo.People", "ReferrerDoctorId");
            DropColumn("dbo.People", "CurrentDoctorId");
            DropColumn("dbo.People", "PatientID");
            DropColumn("dbo.People", "DoctorWorkplaceId");
            AddPrimaryKey("dbo.TypeAppointments", "Id");
            AddPrimaryKey("dbo.Insurances", "Id");
            AddPrimaryKey("dbo.DoctorWorkplaces", "Id");
            AddPrimaryKey("dbo.DoctorSpecialties", "Id");
            AddPrimaryKey("dbo.AppointmentPlaces", "Id");
        }
    }
}
