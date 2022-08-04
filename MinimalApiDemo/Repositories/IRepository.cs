using MinimalApiDemo.Models;

namespace MinimalApiDemo.Repositories
{
    public interface IRepository
    {
       Task< IEnumerable<JobCategory>> GetJobCategories();
        Task<JobCategory>PostJobCategory(JobCategory jobCategory);
    }
}
