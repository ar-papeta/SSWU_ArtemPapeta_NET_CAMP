using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesStore.Authorization.Requirements
{
    public class RoleAuthorizationRequiment : IAuthorizationRequirement
    {
        public string Permission { get; private set; }
        public RoleAuthorizationRequiment(string permission)
        {
            Permission = permission;
        }
    }
}
