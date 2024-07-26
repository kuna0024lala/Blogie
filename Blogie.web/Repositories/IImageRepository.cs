namespace Blogie.web.Repositories
{
    public interface IImageRepository
    {
        Task<string>UploadAsync(IFormFile file);
    }
}
