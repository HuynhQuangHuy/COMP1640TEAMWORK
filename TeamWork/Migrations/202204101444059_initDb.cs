namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ideas", "ItemId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ideas", "ItemId");
            AddForeignKey("dbo.Ideas", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ideas", "ItemId", "dbo.Items");
            DropIndex("dbo.Ideas", new[] { "ItemId" });
            DropColumn("dbo.Ideas", "ItemId");
        }
    }
}
