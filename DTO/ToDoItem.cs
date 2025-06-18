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
        public DateTime creationTime { get; set; } = DateTime.Now;

        public DateTime completionTime { get; set; }
        public DateTime? deadLineTime { get; set; } = DateTime.Now.AddDays(1); // Default to one day after creation
        public ToDoItem() { }
        public ToDoItem(Guid id, string description, bool isCompleted)
        {
            Id = id;
            Description = description;
            IsCompleted = isCompleted;
        }

    }
}
