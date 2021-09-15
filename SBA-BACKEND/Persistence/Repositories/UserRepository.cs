using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Persistence.Contexts;
using SBA_BACKEND.Domain.Persistence.Repositories;

namespace SBA_BACKEND.Persistence.Repositories
{
	public class UserRepository : BaseRepository, IUserRepository
	{

		public UserRepository(AppDbContext context) : base(context)
		{
		}

		public async Task AddAsync(User user)
		{
			await _context.Users.AddAsync(user);
		}

		public async Task<User> FindById(int id)
		{
			List<User> users = await _context.Users
			   .Where(user => user.Id == id)
			   .Include(user => user.District)
			   .ToListAsync();
			return users.First();
		}

		public async Task<IEnumerable<User>> ListAsync()
		{
			return await _context.Users
				.Include(user => user.District)
				.ToListAsync();
		}

		public void Remove(User user)
		{
			_context.Users.Remove(user);
		}

		public void Update(User user)
		{
			_context.Users.Update(user);
		}
	}
}
