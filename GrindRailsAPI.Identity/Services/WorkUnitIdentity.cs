using GrindRailsAPI.Identity.Data;
using GrindRailsAPI.Identity.Interfaces;

namespace GrindRailsAPI.Identity.Services
{
    public class WorkUnitIdentity : IWorkUnitIdentity
    {
        private readonly IdentityDataContext _indentityDataContext;

        public WorkUnitIdentity(IdentityDataContext indentityDataContext)
        {
            _indentityDataContext = indentityDataContext;
            _indentityDataContext.Database.BeginTransaction();
        }

        public async Task SaveChangesAsync()
        {
            await _indentityDataContext.SaveChangesAsync();
        }

        public async Task CommitAsync()
        {
            await _indentityDataContext.Database.CommitTransactionAsync();
        }

        public void Rollback()
        {
            _indentityDataContext.Database.RollbackTransaction();
        }

        public async Task DeleteAsync()
        {
            await _indentityDataContext.Database.EnsureDeletedAsync();
        }
    }
}
