namespace WebBeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteHopsListToBeerTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hops", "BeerId", "dbo.Beers");
            DropIndex("dbo.Hops", new[] { "BeerId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Hops", "BeerId");
            AddForeignKey("dbo.Hops", "BeerId", "dbo.Beers", "Id", cascadeDelete: true);
        }
    }
}
