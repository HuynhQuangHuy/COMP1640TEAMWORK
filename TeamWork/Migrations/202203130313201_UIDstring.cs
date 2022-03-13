namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UIDstring : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Ideas", new[] { "User_Id" });
            DropColumn("dbo.Ideas", "UserId");
            RenameColumn(table: "dbo.Ideas", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Ideas", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Ideas", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ideas", new[] { "UserId" });
            AlterColumn("dbo.Ideas", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Ideas", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Ideas", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ideas", "User_Id");
        }
    }
}
