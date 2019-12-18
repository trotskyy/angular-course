using AngularCourseBE.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AngularCourseBE.Services
{
    public sealed class TaskService
    {
        private static readonly List<Task> _tasks = new List<Task>
        {
            new Task
            {
                Id = 1,
                Name = "Learn Angular",
                CreatedAt = new DateTime(2019, 12, 15, 9, 15, 0),
                Description = "Here is description",
                SubTasks = new List<SubTask>
                {
                    new SubTask
                    {
                        Id = 1,
                        Name = "Learn Components",
                        Description = "they consist of typescript class and html",
                        EstimateHours = 8
                    },
                    new SubTask
                    {
                        Id = 2,
                        Name = "Learn Services",
                        Description = "classes that can be injected into components",
                        EstimateHours = 5
                    },
                    new SubTask
                    {
                        Id = 3,
                        Name = "Learn angular CLI commands",
                        Description = "ng generate component, service...",
                        EstimateHours = 2
                    },
                    new SubTask
                    {
                        Id = 4,
                        Name = "Learn pipes",
                        Description = "Special classes to transform values in component mark-up",
                        EstimateHours = 1
                    }
                }
            },

            new Task
            {
                Id = 2,
                Name = "Learn JS",
                Description = "Here is description",
                CreatedAt = new DateTime(2019, 12, 18, 10, 15, 0),
                SubTasks = new List<SubTask>
                {
                    new SubTask
                    {
                        Id = 21,
                        Name = "Learn Types",
                        Description = "boolean, number, string, null, undefined, [Symbol] and BigInt",
                        EstimateHours = 8
                    },
                    new SubTask
                    {
                        Id = 22,
                        Name = "Learn Execution contexts",
                        Description = "lexical environment and this binding",
                        EstimateHours = 5
                    },
                }
            }
        };


        public bool TryGet(int id, out Task task)
        {
            task = _tasks.FirstOrDefault(t => t.Id == id);
            return task != null;
        }

        public IEnumerable<TaskListItem> GetAll()
        {
            return _tasks.Select(task => new TaskListItem
            {
                Id = task.Id,
                Name = task.Name,
                TotalEstimatedHours = task.SubTasks.Select(st => st.EstimateHours).Sum()
            });
        }

        public bool TryUpdate(int id, Task task)
        {
            Task existingTask = _tasks.FirstOrDefault(t => t.Id == id);

            if (existingTask == null)
            {
                return false;
            }

            existingTask.Name = task.Name;
            existingTask.Description = task.Description;
            existingTask.SubTasks = task.SubTasks;

            return true;
        }

        public bool TryDelete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            
            if (task == null)
            {
                return false;
            }

            _tasks.Remove(task);
            return true;
        }

        public void CreateTask(Task task)
        {
            int maxId = _tasks.Select(t => t.Id).Max();
            task.Id = maxId + 1;
            _tasks.Add(task);
        }
    }
}