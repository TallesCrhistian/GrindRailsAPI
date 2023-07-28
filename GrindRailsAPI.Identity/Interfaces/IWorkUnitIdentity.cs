namespace GrindRailsAPI.Identity.Interfaces
{
    public interface IWorkUnitIdentity
    {
        Task CommitAsync();
        Task DeleteAsync();
        void Rollback();
        Task SaveChangesAsync();
    }
}