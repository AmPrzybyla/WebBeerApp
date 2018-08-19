namespace WebBeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteHopsColumnFromBeerTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hops", "Beer_Id", "dbo.Beers");
            DropIndex("dbo.Hops", new[] { "Beer_Id" });
            DropColumn("dbo.Hops", "Beer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Hops", "Beer_Id", c => c.Int());
            CreateIndex("dbo.Hops", "Beer_Id");
            AddForeignKey("dbo.Hops", "Beer_Id", "dbo.Beers", "Id");
        }
    }
}
