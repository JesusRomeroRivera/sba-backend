using SBA_BACKEND.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Persistence.Repositories
{	interface ISpecialityRepository
	{
		Task<IEnumerable<Speciality>> ListAsync();
		Task AddAsync(Speciality speciality);
		Task<Speciality> FindById(int id);
		void Update(Speciality speciality);
		void Remove(Speciality speciality);
	}
}
