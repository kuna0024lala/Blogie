using Microsoft.AspNetCore.Identity;

namespace Blogie.web.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>>GetAll();
    }
}
