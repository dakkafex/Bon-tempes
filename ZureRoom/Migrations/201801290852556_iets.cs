namespace ZureRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iets : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tafels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TableNmr = c.String(),
                        Chairs = c.Int(nullable: false),
                        Combined = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Reservations", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reservations", "Date");
            DropTable("dbo.Tafels");
        }
    }
}
