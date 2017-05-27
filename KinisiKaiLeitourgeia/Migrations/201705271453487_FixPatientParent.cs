namespace KinisiKaiLeitourgeia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixPatientParent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "ParentId", c => c.Int());
        }
    }
}
