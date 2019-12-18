namespace AngularCourseBE.Models
{
    public sealed class SubTask
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int EstimateHours { get; set; }
    }
}