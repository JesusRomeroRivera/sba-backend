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
	public class SpecialityRepository : BaseRepository, ISpecialityRepository
	{

		public SpecialityRepository(AppDbContext context) : base(context)
		{
		}

		public async Task AddAsync(Speciality speciality)
		{
			await _context.Specialities.AddAsync(speciality);
		}

		public async Task<Speciality> FindById(int id)
		{
			List<Speciality> specialitys = await _context.Specialities
			   .Where(speciality => speciality.Id == id)
			   .ToListAsync();
			return specialitys.First();
		}

		public async Task<IEnumerable<Speciality>> ListAsync()
		{
			return await _context.Specialities
				.ToListAsync();
		}

		public void Remove(Speciality speciality)
		{
			_context.Specialities.Remove(speciality);
		}

		public void Update(Speciality speciality)
		{
			_context.Specialities.Update(speciality);
		}
	}
}
