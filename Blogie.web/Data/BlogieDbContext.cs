using Blogie.web.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Blogie.web.Data
{
    public class BlogieDbContext : DbContext
    {
        public BlogieDbContext(DbContextOptions<BlogieDbContext> options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<BlogPostLike> BlogPostLike { get; set; }


        public DbSet<BlogPostComment> BlogPostComment { get; set; }

    }
}