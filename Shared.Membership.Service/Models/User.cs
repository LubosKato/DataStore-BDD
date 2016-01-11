using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Membership.Service.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Team Team { get; set; }

        public string Name { get; set; }
    }
}
