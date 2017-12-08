namespace ZureRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "MenuImage", c => c.String());
            AddColumn("dbo.Menus", "Description", c => c.String());
            DropColumn("dbo.Menus", "Order");
            DropColumn("dbo.Menus", "Details");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "Details", c => c.String());
            AddColumn("dbo.Menus", "Order", c => c.Int(nullable: false));
            DropColumn("dbo.Menus", "Description");
            DropColumn("dbo.Menus", "MenuImage");
        }
    }
}
