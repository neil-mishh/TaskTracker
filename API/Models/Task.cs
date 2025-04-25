using API.Enums;

namespace API.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;
        public Priority Priority { get; set; }
        public int UserId { get; set; }
    }
}
