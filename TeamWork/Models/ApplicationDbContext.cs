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

		public DbSet<Ideas> Ideas { get; set; }
		public DbSet<CategoryOfIdeas> CategoryOfIdeas { get; set; }

		public DbSet<Products> Products { get; set; }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}