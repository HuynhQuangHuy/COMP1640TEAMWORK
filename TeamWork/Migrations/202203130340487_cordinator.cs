namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cordinator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "CoordinatorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Items", "CoordinatorId");
            AddForeignKey("dbo.Items", "CoordinatorId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "CoordinatorId", "dbo.AspNetUsers");
            DropIndex("dbo.Items", new[] { "CoordinatorId" });
            DropColumn("dbo.Items", "CoordinatorId");
        }
    }
}
