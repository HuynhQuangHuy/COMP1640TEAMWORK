namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "NumberOfLikes", c => c.Int(nullable: false));
            AddColumn("dbo.Comments", "NumberOfDislikes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "NumberOfDislikes");
            DropColumn("dbo.Comments", "NumberOfLikes");
        }
    }
}
