namespace TeamWork.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initDb : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Ideas");
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdeaId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdeaUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdeaId = c.Int(nullable: false),
                        CommentId = c.Int(nullable: false),
                        IsThumbUp = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        EndedAt = c.DateTime(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        Decription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Ideas", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Ideas", "ItemId", c => c.Int(nullable: false));
            AddColumn("dbo.Ideas", "UserId", c => c.String());
            AddColumn("dbo.Ideas", "Decription", c => c.String());
            AddPrimaryKey("dbo.Ideas", "Id");
            DropColumn("dbo.Ideas", "IdeaID");
            DropColumn("dbo.Ideas", "NameOfIdea");
            DropColumn("dbo.Ideas", "CategoryOfIdeaID");
            DropColumn("dbo.Ideas", "DateTime");
            DropTable("dbo.CategoryOfIdeas");
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        NameOfProduct = c.String(),
                        CategoryOfProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "dbo.CategoryOfIdeas",
                c => new
                    {
                        CategoryOfIdeaID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CategoryOfIdeaID);
            
            AddColumn("dbo.Ideas", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ideas", "CategoryOfIdeaID", c => c.Int(nullable: false));
            AddColumn("dbo.Ideas", "NameOfIdea", c => c.String());
            AddColumn("dbo.Ideas", "IdeaID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Ideas");
            DropColumn("dbo.Ideas", "Decription");
            DropColumn("dbo.Ideas", "UserId");
            DropColumn("dbo.Ideas", "ItemId");
            DropColumn("dbo.Ideas", "Id");
            DropTable("dbo.Items");
            DropTable("dbo.IdeaUsers");
            DropTable("dbo.Departments");
            DropTable("dbo.Comments");
            DropTable("dbo.Categories");
            AddPrimaryKey("dbo.Ideas", "IdeaID");
        }
    }
}
