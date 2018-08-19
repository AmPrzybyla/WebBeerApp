namespace WebBeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHopsColumnToBeerTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Hops", "Beer_Id", c => c.Int());
            CreateIndex("dbo.Hops", "Beer_Id");
            AddForeignKey("dbo.Hops", "Beer_Id", "dbo.Beers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hops", "Beer_Id", "dbo.Beers");
            DropIndex("dbo.Hops", new[] { "Beer_Id" });
            DropColumn("dbo.Hops", "Beer_Id");
        }
    }
}
