namespace ZureRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TafelSamenWeg : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tafels", "Combined");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tafels", "Combined", c => c.String());
        }
    }
}
