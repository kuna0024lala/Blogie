using Blogie.web.Data;
using Blogie.web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogie.web.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogieDbContext blogieDbContext;

        public BlogPostCommentRepository(BlogieDbContext blogieDbContext)
        {
            this.blogieDbContext = blogieDbContext;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await blogieDbContext.BlogPostComment.AddAsync(blogPostComment);
            await blogieDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
           return await blogieDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId)
                .ToListAsync();
        }
    }
}
