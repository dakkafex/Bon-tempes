namespace ZureRoom.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotationsTafel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tafels", "TableNmr", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tafels", "TableNmr", c => c.String());
        }
    }
}
