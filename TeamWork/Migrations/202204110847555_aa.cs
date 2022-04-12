namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aa : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ThreadId", "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "ThreadId" });
            DropColumn("dbo.Comments", "ThreadId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "ThreadId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "ThreadId");
            AddForeignKey("dbo.Comments", "ThreadId", "dbo.Threads", "ThreadId", cascadeDelete: true);
        }
    }
}
