using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Services.Communications;

namespace SBA_BACKEND.Domain.Services
{
	public interface IOpinionService
	{
		Task<OpinionResponse> GetByIdAsync(int id);
		Task<OpinionResponse> SaveAsync(Opinion opinion);
		Task<OpinionResponse> UpdateAsync(int id, Opinion opinion);
		Task<OpinionResponse> DeleteAsync(int id);

	}
}
