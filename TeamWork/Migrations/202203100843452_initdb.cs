namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ideas", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Ideas", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Ideas", "User_Id");
            AddForeignKey("dbo.Ideas", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ideas", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Ideas", new[] { "User_Id" });
            DropColumn("dbo.Ideas", "User_Id");
            DropColumn("dbo.Ideas", "UserId");
        }
    }
}
