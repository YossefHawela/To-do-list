using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.DTO
{
    public class ToDoItem
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;

        public DateTime CreationTime { get; set; } = DateTime.Now;
        public DateTime CompletionTime { get; set; }
        public DateTime? DeadLineTime { get; set; } = DateTime.Now.AddDays(1);

        // Actual proper foreign key
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public UserAccount User { get; set; } = null!;
        public ToDoItem() { }
        public ToDoItem(Guid id, string description, bool isCompleted)
        {
            Id = id;
            Description = description;
            IsCompleted = isCompleted;
        }

    }
}
