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
	public class SpecialityTechnicianRepository : BaseRepository, ISpecialityTechnicianRepository
	{

		public SpecialityTechnicianRepository(AppDbContext context) : base(context)
		{
		}
		public async Task AddAsync(SpecialityTechnician specialityTechnician)
		{
			await _context.SpecialityTechnicians.AddAsync(specialityTechnician);
		}
		public async Task<SpecialityTechnician> FindById(int specialityId, int technicianId)
		{
			List<SpecialityTechnician> specialityTechnicians = await _context.SpecialityTechnicians
			   .Where(st => st.SpecialityId == specialityId)
			   .Where(st => st.TechnicianId == technicianId)
			   .Include(st => st.Technician)
			   .Include(st => st.Technician.District)
			   .Include(st => st.Speciality)
			   .ToListAsync();
			if (specialityTechnicians.Count == 0)
			{
				return null;
			}
			return specialityTechnicians.First();
		}
		public async Task<IEnumerable<SpecialityTechnician>> ListAsync()
		{
			return await _context.SpecialityTechnicians
			   .Include(st => st.Speciality)
			   .Include(st => st.Technician)
			   .Include(st => st.Technician.District)
			   .ToListAsync();
		}
		public void Remove(SpecialityTechnician specialityTechnician)
		{
			_context.SpecialityTechnicians.Remove(specialityTechnician);
		}

		public void Update(SpecialityTechnician specialityTechnician)
		{
			_context.SpecialityTechnicians.Update(specialityTechnician);
		}

	}
}
