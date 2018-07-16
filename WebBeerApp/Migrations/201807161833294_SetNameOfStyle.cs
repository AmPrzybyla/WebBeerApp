namespace WebBeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfStyle : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT StyleTypes ON");
            Sql("INSERT INTO StyleTypes (Id, Name) VALUES (1, 'Lager')");
            Sql("INSERT INTO StyleTypes (Id, Name) VALUES (2, 'American Pale Ale')");
            Sql("INSERT INTO StyleTypes (Id, Name) VALUES (3, 'India Pale Ale')");
            Sql("INSERT INTO StyleTypes (Id, Name) VALUES (4, 'Stout')");
            Sql("INSERT INTO StyleTypes (Id, Name) VALUES (5, 'American Wheat')");
            Sql("INSERT INTO StyleTypes (Id, Name) VALUES (6, 'Baltic Porter')");
            Sql("INSERT INTO StyleTypes (Id, Name) VALUES (7, 'Weizen')");
            Sql("SET IDENTITY_INSERT StyleTypes OFF");

        }

        public override void Down()
        {
        }
    }
}
