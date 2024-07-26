using Blogie.web.Data;
using Blogie.web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogie.web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogieDbContext blogieDbContext;

        public BlogPostRepository(BlogieDbContext blogieDbContext)
        {
            this.blogieDbContext = blogieDbContext;
        }
        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await blogieDbContext.AddAsync(blogPost);
            await blogieDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<BlogPost?> DeleteAsync(Guid id)
        {
            var existingBlog  = await blogieDbContext.BlogPosts.FindAsync(id);
            if (existingBlog != null)
            {
                blogieDbContext.BlogPosts.Remove(existingBlog);
                await blogieDbContext.SaveChangesAsync();   
                return existingBlog;
            }

            return null;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
           return await blogieDbContext.BlogPosts.Include(x => x.Tags).ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(Guid id)
        {
           return await blogieDbContext.BlogPosts.Include(X => X.Tags).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost?> GetByUrlHandleAsync(string urlHandle)
        {
           return await blogieDbContext.BlogPosts.Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.UrlHandle == urlHandle);
        }

        public async Task<BlogPost?> UpdateAsync(BlogPost blogPost)
        {
          var existingBlog =  await blogieDbContext.BlogPosts.Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            if (existingBlog != null)
            {
                existingBlog.Id = blogPost.Id;
                existingBlog.Heading = blogPost.Heading;
                existingBlog.Author = blogPost.Author;
                existingBlog.Content = blogPost.Content;
                existingBlog.PageTitle = blogPost.PageTitle;
                existingBlog.PublishedDate = blogPost.PublishedDate;
                existingBlog.ShortDescription = blogPost.ShortDescription;
                existingBlog.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlog.UrlHandle = blogPost.UrlHandle;
                existingBlog.Visible = blogPost.Visible;
                existingBlog.Tags = blogPost.Tags;


                await blogieDbContext.SaveChangesAsync();
                return existingBlog;
            }

            return null;
        }
    }
}
