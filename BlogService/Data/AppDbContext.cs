﻿using BlogService.Entity;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace BlogService.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Comment>()
                .Property(e => e.LastUpdated)
                .HasComputedColumnSql("GETDATE()");

            modelBuilder.Entity<Post>()
                .Property(e => e.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Post>()
                .Property(e => e.LastUpdated)
                .HasComputedColumnSql("GETDATE()");
        }
    }
}
