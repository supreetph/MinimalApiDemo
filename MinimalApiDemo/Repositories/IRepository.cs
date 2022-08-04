using MinimalApiDemo.Models;

namespace MinimalApiDemo.Repositories
{
    public interface IRepository
    {
        IEnumerable<JobCategory> GetJobCategories();
    }
}
