namespace WenShenERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Provinces", "PrimaryCity", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Provinces", "PrimaryCity");
        }
    }
}
