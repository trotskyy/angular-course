using System;
using System.Collections.Generic;

namespace AngularCourseBE.Models
{
    public sealed class Task
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<SubTask> SubTasks { get; set; }
    }
}