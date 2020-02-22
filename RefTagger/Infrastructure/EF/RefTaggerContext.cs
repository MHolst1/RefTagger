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

        public DbSet<ImageReference> ImageReferences { get; set; }
        public DbSet<ImageReferenceTag> ImageReferenceTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
