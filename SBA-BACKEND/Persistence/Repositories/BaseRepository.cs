using System;
using SBA_BACKEND.Domain.Persistence.Contexts;

namespace SBA_BACKEND.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
