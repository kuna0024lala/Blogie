
using Blogie.web.Data;
using Blogie.web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogie.web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BlogieDbContext blogieDbContext;

        public BlogPostLikeRepository(BlogieDbContext blogieDbContext)
        {
            this.blogieDbContext = blogieDbContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await blogieDbContext.BlogPostLike.AddAsync(blogPostLike);
            await blogieDbContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await blogieDbContext.BlogPostLike.Where(x=> x.BlogPostId == blogPostId)
                .ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
             return  await blogieDbContext.BlogPostLike
                .CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
