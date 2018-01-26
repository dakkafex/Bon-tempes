namespace ZureRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReservationNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "Message", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Message");
        }
    }
}
