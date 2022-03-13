using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TeamWork.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("Team4", throwIfV1Schema: false)
		{
		}
		public DbSet<FileUpload> FileUploads { get; set; }
		public DbSet<FileClass> Fileclasses { get; set; }

		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Idea> Ideas { get; set; }
		public DbSet<IdeaUser> IdeaUsers { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Department> Departments { get; set; }




		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}