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
	public class DistrictRepository : BaseRepository, IDistrictRepository
	{

		public DistrictRepository(AppDbContext context) : base(context)
		{
		}

		public async Task AddAsync(District district)
		{
			await _context.Districts.AddAsync(district);
		}

		public async Task<District> FindById(int id)
		{
			List<District> districts = await _context.Districts
			   .Where(district => district.Id == id)
			   .ToListAsync();
			return districts.First();
		}

		public async Task<IEnumerable<District>> ListAsync()
		{
			return await _context.Districts
				.ToListAsync();
		}

		public void Remove(District district)
		{
			_context.Districts.Remove(district);
		}

		public void Update(District district)
		{
			_context.Districts.Update(district);
		}
	}
}
