using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
	public interface ITechnicalService
	{
		Task<TechnicalResponse> GetByIdAsync(int id);
		Task<TechnicalResponse> SaveAsync(Technical technical);
		Task<TechnicalResponse> UpdateAsync(int id, Technical technical);
		Task<TechnicalResponse> DeleteAsync(int id);

	}
}
