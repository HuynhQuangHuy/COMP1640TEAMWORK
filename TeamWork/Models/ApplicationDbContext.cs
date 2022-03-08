using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace TeamWork.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public DbSet<Idea> Ideas { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<IdeaUser> IdeasUsers { get; set; }
		



		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}