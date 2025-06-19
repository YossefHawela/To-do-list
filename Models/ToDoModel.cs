using System.Security.Claims;

namespace ToDoList.Models
{
    public class ToDoModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public DateTime? CreationTime { get; set; }

        public DateTime CompletionTime { get; set; }

        public DateTime? DeadLineTime { get; set; }

        public Guid UserId { get; set; }

        public bool inEditMode { get; set; } = false;


    }
}
