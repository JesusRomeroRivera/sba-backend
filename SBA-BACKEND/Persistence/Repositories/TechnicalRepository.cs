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
	public class TechnicalRepository : BaseRepository, ITechnicalRepository
	{

		public TechnicalRepository(AppDbContext context) : base(context)
		{
		}

		public async Task AddAsync(Technical technical)
		{
			await _context.Technicals.AddAsync(technical);
		}

		public async Task<Technical> FindById(int id)
		{
			List<Technical> technicals = await _context.Technicals
			   .Where(technical => technical.Id == id)
			   .Include(technical => technical.District)
			   .ToListAsync();
			return technicals.First();
		}

		public async Task<IEnumerable<Technical>> ListAsync()
		{
			return await _context.Technicals
				.Include(technical => technical.District)
				.ToListAsync();
		}

		public void Remove(Technical technical)
		{
			_context.Technicals.Remove(technical);
		}

		public void Update(Technical technical)
		{
			_context.Technicals.Update(technical);
		}
	}
}
