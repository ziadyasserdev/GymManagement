using GymManagement.DAL.Data.Contexts;
using GymManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagement.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymDbContext _context;
        public UnitOfWork(GymDbContext _context)
        {
            this._context = _context;
            Plans = new PlanRepository(_context);
            Bookings = new BookingRepository(_context);
            Memberships = new MembershipRepository(_context);
            Sessions = new SessionRepository(_context);

        }

        private bool _disposed = false;

        public IPlanRepository Plans { get; private set; } = null!;

        public IBookingRepository Bookings { get; private set; } = null!;

        public IMembershipRepository Memberships { get; private set; } = null!;

        public ISessionRepository Sessions { get; private set; } = null!;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

      
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

      
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
