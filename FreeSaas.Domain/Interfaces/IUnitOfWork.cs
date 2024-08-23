namespace FreeSaas.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void CommitAndRefreshChanges();

        void RollbackChanges();

        void ChangeDatabase(string database);

        string GetDatabase();

        string GetConnectionString();

        void EnableChangeTracking(bool enable = true);
    }
}
