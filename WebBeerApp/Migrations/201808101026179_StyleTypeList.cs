namespace WebBeerApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StyleTypeList : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT StyleTypes ON");
            Sql("INSERT INTO StyleTypes (Id, Name) Values(1, 'Lager')");
            Sql("INSERT INTO StyleTypes (Id, Name) Values(2, 'Pale Ale')");
            Sql("INSERT INTO StyleTypes (Id, Name) Values(3, 'Witbier')");
            Sql("INSERT INTO StyleTypes (Id, Name) Values(4, 'Stout')");
            Sql("SET IDENTITY_INSERT StyleTypes OFF");

        }

        public override void Down()
        {
        }
    }
}
