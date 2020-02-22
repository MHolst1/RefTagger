using Microsoft.EntityFrameworkCore;
using RefTagger.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefTagger.Infrastructure.EF
{
    public class RefTaggerContext : DbContext
    {
        public RefTaggerContext(DbContextOptions<RefTaggerContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<ImageTag> ImageTags { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImageTag>(it =>
            {
                it.Property(x => x.ImageFileName)
                    .HasMaxLength(256);

                it.HasIndex(x => x.ImageFileName);

                it.HasIndex(x => new { x.ImageFileName, x.TagId })
                    .IsUnique();
            });

            modelBuilder.Entity<Tag>(t =>
            {
                t.Property(x => x.Description)
                    .HasMaxLength(50);

                t.HasIndex(x => x.Description)
                    .IsUnique();
            });
        }
    }
}
