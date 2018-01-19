namespace ZureRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class translation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Phone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Contacts", "Message", c => c.String(nullable: false));
            AlterColumn("dbo.Reservations", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Reservations", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Reservations", "Phone", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reservations", "Phone", c => c.String());
            AlterColumn("dbo.Reservations", "Email", c => c.String());
            AlterColumn("dbo.Reservations", "Name", c => c.String());
            AlterColumn("dbo.Contacts", "Message", c => c.String());
            AlterColumn("dbo.Contacts", "Phone", c => c.String());
            AlterColumn("dbo.Contacts", "Email", c => c.String());
            AlterColumn("dbo.Contacts", "Name", c => c.String());
        }
    }
}
