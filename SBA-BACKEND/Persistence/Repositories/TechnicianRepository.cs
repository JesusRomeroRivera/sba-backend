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
	public class TechnicianRepository : BaseRepository, ITechnicianRepository
	{

		public TechnicianRepository(AppDbContext context) : base(context)
		{
		}

		public async Task AddAsync(Technician technician)
		{
			await _context.Technicians.AddAsync(technician);
		}

		public async Task<Technician> FindById(int id)
		{
			List<Technician> technicians = await _context.Technicians
			   .Where(technician => technician.Id == id)
			   .Include(technician => technician.District)
			   .ToListAsync();
			return technicians.First();
		}

		public async Task<IEnumerable<Technician>> ListAsync()
		{
			return await _context.Technicians
				.Include(technician => technician.District)
				.ToListAsync();
		}

		public void Remove(Technician technician)
		{
			_context.Technicians.Remove(technician);
		}

		public void Update(Technician technician)
		{
			_context.Technicians.Update(technician);
		}
	}
}
