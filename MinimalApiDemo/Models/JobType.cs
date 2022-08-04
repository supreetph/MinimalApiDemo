using System;
using System.Collections.Generic;

namespace MinimalApiDemo.Models
{
    public partial class JobType
    {
        public JobType()
        {
            Jobs = new HashSet<Job>();
        }

        public int JobTypeId { get; set; }
        public string? JobTypeDescription { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
