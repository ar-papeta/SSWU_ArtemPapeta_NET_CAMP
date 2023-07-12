using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Helpers.Interfaces
{
    public interface IPasswordHash
    {
        public string EncryptPassword(string password, byte[] salt);
    }
}
