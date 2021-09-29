using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Persistence.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
