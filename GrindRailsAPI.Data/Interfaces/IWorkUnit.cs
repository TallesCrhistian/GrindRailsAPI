namespace GrindRailsAPI.Data.Interfaces
{
    public interface IWorkUnit
    {
        Task CommitAsync();
        Task DeleteAsync();
        void Rollback();
        Task SaveChangesAsync();
    }
}