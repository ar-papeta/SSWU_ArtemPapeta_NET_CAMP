using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork 
    {
        public IRepository<Comment> Comments { get; }
        public IRepository<Director> Directors { get; }
        public IRepository<Genre> Genres { get; }
        public IRepository<Movie> Movies { get; }
        public IRepository<User> Users { get; }
        public void Save();
    }
}
