using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Membership.Service.Models;

namespace Shared.Membership.Service
{
    public class UserService : IUserService
    {
        public User GetCurrentUser()
        {
            return new User();
        }
    }
}
