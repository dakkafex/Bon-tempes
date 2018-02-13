namespace ZureRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class htmlp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reservations", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Reservations", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Reservations", "Phone", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "Phone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Reservations", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Reservations", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
