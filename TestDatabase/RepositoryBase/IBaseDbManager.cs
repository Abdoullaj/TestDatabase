
using TestDatabase.Model;

namespace TestDatabase.RepositoryBase
{
    public interface IBaseDbManager
    {
        int SaveChanges();
        void ShowErrors(ValutationResults validation);
    }
}
