namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileUploads",
                c => new
                    {
                        FileId = c.String(nullable: false, maxLength: 128),
                        FileName = c.String(),
                        FileUrl = c.String(),
                    })
                .PrimaryKey(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FileUploads");
        }
    }
}
