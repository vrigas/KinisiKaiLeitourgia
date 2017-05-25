namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCascadeDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.People", "DoctorSpecialtyId", "dbo.DoctorSpecialties");
            DropForeignKey("dbo.People", "DoctorWorkplaceId", "dbo.DoctorSpecialties");
            DropForeignKey("dbo.People", "InsuranceID", "dbo.Insurances");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.People", "DoctorSpecialtyId", "dbo.DoctorSpecialties", "Id");
            AddForeignKey("dbo.People", "DoctorWorkplaceId", "dbo.DoctorSpecialties", "Id");
            AddForeignKey("dbo.People", "InsuranceID", "dbo.Insurances", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.People", "InsuranceID", "dbo.Insurances");
            DropForeignKey("dbo.People", "DoctorWorkplaceId", "dbo.DoctorSpecialties");
            DropForeignKey("dbo.People", "DoctorSpecialtyId", "dbo.DoctorSpecialties");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.People", "InsuranceID", "dbo.Insurances", "Id", cascadeDelete: true);
            AddForeignKey("dbo.People", "DoctorWorkplaceId", "dbo.DoctorSpecialties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.People", "DoctorSpecialtyId", "dbo.DoctorSpecialties", "Id", cascadeDelete: true);
        }
    }
}
