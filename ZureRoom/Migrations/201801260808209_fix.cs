namespace ZureRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "MenuImage_ID", "dbo.MenuPics");
            DropIndex("dbo.Menus", new[] { "MenuImage_ID" });
            AddColumn("dbo.Menus", "MenuImage", c => c.String());
            AddColumn("dbo.Reservations", "Message", c => c.String(maxLength: 250));
            DropColumn("dbo.Menus", "MenuImage_ID");
            DropTable("dbo.MenuPics");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MenuPics",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PicPlace = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Menus", "MenuImage_ID", c => c.Int());
            DropColumn("dbo.Reservations", "Message");
            DropColumn("dbo.Menus", "MenuImage");
            CreateIndex("dbo.Menus", "MenuImage_ID");
            AddForeignKey("dbo.Menus", "MenuImage_ID", "dbo.MenuPics", "ID");
        }
    }
}
