namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DoctorFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "DoctorSpecialtyId", c => c.Byte());
            CreateIndex("dbo.People", "DoctorSpecialtyId");
            AddForeignKey("dbo.People", "DoctorSpecialtyId", "dbo.DoctorSpecialties", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.People", "DoctorSpecialtyId", "dbo.DoctorSpecialties");
            DropIndex("dbo.People", new[] { "DoctorSpecialtyId" });
            DropColumn("dbo.People", "DoctorSpecialtyId");
        }
    }
}
