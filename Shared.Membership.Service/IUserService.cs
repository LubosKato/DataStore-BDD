using Shared.Membership.Service.Models;

namespace Shared.Membership.Service
{
    public interface IUserService
    {
        User GetCurrentUser();
    }
}