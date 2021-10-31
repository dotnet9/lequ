﻿using Lequ.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
	public class Context : DbContext
	{
		public DbSet<About>? Abouts { get; set; }
		public DbSet<Admin>? Admins { get; set; }
		public DbSet<Author>? Authors { get; set; }
		public DbSet<Blog>? Blogs { get; set; }
		public DbSet<Category>? Categories { get; set; }
		public DbSet<Comment>? Comments { get; set; }
		public DbSet<Contact>? Contacts { get; set; }

		public Context(DbContextOptions<Context> options) : base(options)
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

			modelBuilder.Seed();
		}
	}
}
