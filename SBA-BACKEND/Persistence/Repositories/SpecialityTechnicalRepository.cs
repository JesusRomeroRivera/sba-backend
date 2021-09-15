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
	public class SpecialityTechnicalRepository : BaseRepository, ISpecialityTechnicalRepository
	{

		public SpecialityTechnicalRepository(AppDbContext context) : base(context)
		{
		}
		public async Task AddAsync(SpecialityTechnical specialityTechnical)
		{
			await _context.SpecialityTechnicals.AddAsync(specialityTechnical);
		}
		public async Task<SpecialityTechnical> FindById(int specialityId, int technicalId)
		{
			List<SpecialityTechnical> specialityTechnicals = await _context.SpecialityTechnicals
			   .Where(st => st.SpecialityId == specialityId)
			   .Where(st => st.TechnicalId == technicalId)
			   .Include(st => st.Technical)
			   .Include(st => st.Technical.District)
			   .Include(st => st.Speciality)
			   .ToListAsync();
			if (specialityTechnicals.Count == 0)
			{
				return null;
			}
			return specialityTechnicals.First();
		}
		public async Task<IEnumerable<SpecialityTechnical>> ListAsync()
		{
			return await _context.SpecialityTechnicals
			   .Include(st => st.Speciality)
			   .Include(st => st.Technical)
			   .Include(st => st.Technical.District)
			   .ToListAsync();
		}
		public void Remove(SpecialityTechnical specialityTechnical)
		{
			_context.SpecialityTechnicals.Remove(specialityTechnical);
		}

		public void Update(SpecialityTechnical specialityTechnical)
		{
			_context.SpecialityTechnicals.Update(specialityTechnical);
		}

	}
}
