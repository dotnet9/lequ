using Lequ.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
	public class LequDbContext : DbContext
	{
		public DbSet<About>? Abouts { get; set; }
		public DbSet<Admin>? Admins { get; set; }
		public DbSet<User>? Authors { get; set; }
		public DbSet<Blog>? Blogs { get; set; }
		public DbSet<Category>? Categories { get; set; }
		public DbSet<Comment>? Comments { get; set; }
		public DbSet<Contact>? Contacts { get; set; }

		public LequDbContext(DbContextOptions<LequDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<BlogCategory>()
				.HasKey(t => new { t.BlogID, t.CategoryID });

			modelBuilder.Entity<BlogCategory>()
				.HasOne(pt => pt.Blog)
				.WithMany(p => p.BlogCategories)
				.HasForeignKey(pt => pt.BlogID);

			modelBuilder.Entity<BlogCategory>()
				.HasOne(pt => pt.Category)
				.WithMany(t => t.BlogCategories)
				.HasForeignKey(pt => pt.CategoryID);


			modelBuilder.Entity<BlogTag>()
				.HasKey(t => new { t.BlogID, t.TagID });

			modelBuilder.Entity<BlogTag>()
				.HasOne(pt => pt.Blog)
				.WithMany(p => p.BlogTags)
				.HasForeignKey(pt => pt.BlogID);

			modelBuilder.Entity<BlogTag>()
				.HasOne(pt => pt.Tag)
				.WithMany(t => t.BlogTags)
				.HasForeignKey(pt => pt.TagID);


			modelBuilder.Entity<BlogAlbum>()
				.HasKey(t => new { t.BlogID, t.AlbumID });

			modelBuilder.Entity<BlogAlbum>()
				.HasOne(pt => pt.Blog)
				.WithMany(p => p.BlogAlbums)
				.HasForeignKey(pt => pt.BlogID);

			modelBuilder.Entity<BlogAlbum>()
				.HasOne(pt => pt.Album)
				.WithMany(t => t.BlogAlbums)
				.HasForeignKey(pt => pt.AlbumID);

			modelBuilder.Seed();
		}
	}
}
