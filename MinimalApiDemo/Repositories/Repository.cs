using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<JobCategory>> GetJobCategories()
        {
            return await _context.JobCategories.ToListAsync();
        }

        public async Task<JobCategory> PostJobCategory(JobCategory jobCategory)
        {
          await _context.JobCategories.AddAsync(jobCategory);
            _context.SaveChanges();
            return jobCategory;
        }
    }
}
