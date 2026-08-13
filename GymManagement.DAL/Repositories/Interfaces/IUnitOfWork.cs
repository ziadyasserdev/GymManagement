using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPlanRepository Plans { get; }  
        Task<IDbContextTransaction> BeginTransactionAsync();

        Task<int> SaveAsync();
    }
}
