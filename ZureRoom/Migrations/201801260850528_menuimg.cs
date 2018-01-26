namespace ZureRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuimg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuImgs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuImgPlace = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Menus", "MenuImg_Id", c => c.Int());
            CreateIndex("dbo.Menus", "MenuImg_Id");
            AddForeignKey("dbo.Menus", "MenuImg_Id", "dbo.MenuImgs", "Id");
            DropColumn("dbo.Menus", "MenuImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "MenuImage", c => c.String());
            DropForeignKey("dbo.Menus", "MenuImg_Id", "dbo.MenuImgs");
            DropIndex("dbo.Menus", new[] { "MenuImg_Id" });
            DropColumn("dbo.Menus", "MenuImg_Id");
            DropTable("dbo.MenuImgs");
        }
    }
}
