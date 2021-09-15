using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
	public interface IUserService
	{
		Task<UserResponse> GetByIdAsync(int id);
		Task<UserResponse> SaveAsync(User user);
		Task<UserResponse> UpdateAsync(int id, User user);
		Task<UserResponse> DeleteAsync(int id);

	}
}
