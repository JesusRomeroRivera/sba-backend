using SBA_BACKEND.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Persistence.Repositories
{
	public interface IReportRepository
	{
		Task<IEnumerable<Report>> ListAsync();
		Task AddAsync(Report report);
		Task<Report> FindById(int id);
		void Update(Report report);
		void Remove(Report report);
	}
}
