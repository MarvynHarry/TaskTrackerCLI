namespace TaskTrackerCLI.Models
{
    public class Task
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; } // "todo", "in-progress", or "done"
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
