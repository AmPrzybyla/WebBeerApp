namespace WebBeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBeerIdColumnToHopsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hops", "BeerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Hops", "BeerId");
        }
    }
}
