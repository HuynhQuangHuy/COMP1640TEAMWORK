namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class I : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.IdeaUsers", "IdeaId");
            AddForeignKey("dbo.IdeaUsers", "IdeaId", "dbo.Ideas", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdeaUsers", "IdeaId", "dbo.Ideas");
            DropIndex("dbo.IdeaUsers", new[] { "IdeaId" });
        }
    }
}
