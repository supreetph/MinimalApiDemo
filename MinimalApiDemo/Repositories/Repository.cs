using MinimalApiDemo.Models;

namespace MinimalApiDemo.Repositories
{
    public class Repository:IRepository
    {
        private readonly RecruitmentContext _context;

        public Repository(RecruitmentContext context)
        {
            _context = context;
        }

        public IEnumerable<JobCategory> GetJobCategories()
        {
            return _context.JobCategories.ToList();
        }
    }
}
