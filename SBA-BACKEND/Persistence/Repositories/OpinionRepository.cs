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
	public class OpinionRepository : BaseRepository, IOpinionRepository
	{

		public OpinionRepository(AppDbContext context) : base(context)
		{
		}

		public async Task AddAsync(Opinion opinion)
		{
			await _context.Opinions.AddAsync(opinion);
		}

		public async Task<Opinion> FindById(int id)
		{
			List<Opinion> opinions = await _context.Opinions
			   .Where(opinion => opinion.Id == id)
			   .Include(opinion => opinion.Customer)
			   .Include(opinion => opinion.Customer.District)
			   .Include(opinion => opinion.Technical)
			   .Include(opinion => opinion.Technical.District)
			   .ToListAsync();
			return opinions.First();
		}

		public async Task<IEnumerable<Opinion>> ListAsync()
		{
			return await _context.Opinions
				.Include(opinion => opinion.Customer)
			    .Include(opinion => opinion.Customer.District)
			    .Include(opinion => opinion.Technical)
			    .Include(opinion => opinion.Technical.District)
				.ToListAsync();
		}

		public void Remove(Opinion opinion)
		{
			_context.Opinions.Remove(opinion);
		}

		public void Update(Opinion opinion)
		{
			_context.Opinions.Update(opinion);
		}
	}
}
