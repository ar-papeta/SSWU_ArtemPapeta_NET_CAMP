using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _context;
        private IRepository<Comment> _commentRepository;
        private IRepository<Director> _directorRepository;
        private IRepository<Genre> _genreRepository;
        private IRepository<Movie> _movieRepository;
        private IRepository<User> _userRepository;

        public UnitOfWork(StoreContext context)
        {
            _context = context;
        }

        public IRepository<User> Users
        {
            get
            {
                if (_userRepository is null)
                {
                    _userRepository = new GenericRepository<User>(_context);
                }
                return _userRepository;
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                if (_commentRepository is null)
                {
                    _commentRepository = new GenericRepository<Comment>(_context);
                }
                return _commentRepository;
            }
        }

        public IRepository<Director> Directors
        {
            get
            {
                if (this._directorRepository is null)
                {
                    this._directorRepository = new GenericRepository<Director>(_context);
                }
                return _directorRepository;
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                if (_genreRepository is null)
                {
                    _genreRepository = new GenericRepository<Genre>(_context);
                }
                return _genreRepository;
            }
        }

        public IRepository<Movie> Movies
        {
            get
            {
                if (_movieRepository is null)
                {
                    _movieRepository = new GenericRepository<Movie>(_context);
                }
                return _movieRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
