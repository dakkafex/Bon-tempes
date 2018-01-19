namespace ZureRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "MenuName", c => c.String());
            AddColumn("dbo.Reservations", "Amount", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "MenuID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "MenuID", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "Amount");
            DropColumn("dbo.Reservations", "MenuName");
        }
    }
}
