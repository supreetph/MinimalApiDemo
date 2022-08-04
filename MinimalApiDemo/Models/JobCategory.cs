using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MinimalApiDemo.Models
{
    public partial class JobCategory
    {
        public JobCategory()
        {
            Jobs = new HashSet<Job>();
        }
        [Key]
        public int JobCategoryId { get; set; }
        public string JobCategoryDescription { get; set; } = null!;

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
