namespace ZureRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tafel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Tafel", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Tafel");
        }
    }
}
