namespace AngularCourseBE.Services
{
    public sealed class TaskListItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalEstimatedHours { get; set; }
    }
}