namespace WebBeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecipesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Beer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Beers", t => t.Beer_Id)
                .Index(t => t.Beer_Id);
            
            AddColumn("dbo.Hops", "Recipe_Id", c => c.Int());
            CreateIndex("dbo.Hops", "Recipe_Id");
            AddForeignKey("dbo.Hops", "Recipe_Id", "dbo.Recipes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hops", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "Beer_Id", "dbo.Beers");
            DropIndex("dbo.Recipes", new[] { "Beer_Id" });
            DropIndex("dbo.Hops", new[] { "Recipe_Id" });
            DropColumn("dbo.Hops", "Recipe_Id");
            DropTable("dbo.Recipes");
        }
    }
}
