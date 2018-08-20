namespace WebBeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHopsListToBeerTable : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Hops", "BeerId");
            AddForeignKey("dbo.Hops", "BeerId", "dbo.Beers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hops", "BeerId", "dbo.Beers");
            DropIndex("dbo.Hops", new[] { "BeerId" });
        }
    }
}
