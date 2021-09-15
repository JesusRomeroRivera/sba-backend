using SBA_BACKEND.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Persistence.Repositories
{	interface IUserRepository
	{
		Task<IEnumerable<User>> ListAsync();
		Task AddAsync(User user);
		Task<User> FindById(int id);
		void Update(User user);
		void Remove(User user);
	}
}
