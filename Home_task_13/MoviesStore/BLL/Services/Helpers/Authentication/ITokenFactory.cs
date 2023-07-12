using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesStore.Authentication
{
    public interface ITokenFactory
    {
        public string CreateToken(string userId, string userRole);
    }
}
