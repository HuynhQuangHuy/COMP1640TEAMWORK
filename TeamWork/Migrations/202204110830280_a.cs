namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Threads",
                c => new
                    {
                        ThreadId = c.Int(nullable: false, identity: true),
                        LikeCount = c.Int(nullable: false),
                        DislikeCount = c.Int(nullable: false),
                        SecretPoll = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ThreadId);
            
            AddColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Comments", "IsLike", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "ThreadId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.Comments", "ThreadId");
            AddForeignKey("dbo.Comments", "ThreadId", "dbo.Threads", "ThreadId", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "ThreadId", "dbo.Threads");
            DropIndex("dbo.Comments", new[] { "ThreadId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropColumn("dbo.Comments", "ThreadId");
            DropColumn("dbo.Comments", "IsLike");
            DropColumn("dbo.Comments", "UserId");
            DropTable("dbo.Threads");
        }
    }
}
