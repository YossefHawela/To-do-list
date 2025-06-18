using Microsoft.EntityFrameworkCore;
using ToDoList.DTO;

namespace ToDoList.Data
{
    public class DataConnector
    {

        private readonly ToDoDataContext _context;

   
        public IEnumerable<ToDoItem> ToDoItems
        {
            get
            {
                return _context.toDoItems;
            }
        }


        public DataConnector(ToDoDataContext context)
        {
            _context = context;
        }

        public void Update(ToDoItem toDoItem)
        {
            if (toDoItem == null)
            {
                throw new ArgumentNullException(nameof(toDoItem), "ToDo item cannot be null.");
            }
            var existingItem = _context.toDoItems.FirstOrDefault(item => item.Id == toDoItem.Id);

            if (existingItem != null)
            {
                // Update the existing item with the new values
                existingItem.Title = toDoItem.Title;
                existingItem.Description = toDoItem.Description;
                existingItem.IsCompleted = toDoItem.IsCompleted;
                existingItem.deadLineTime = toDoItem.deadLineTime;
                existingItem.completionTime = toDoItem.completionTime;

                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException($"ToDo item with ID {toDoItem.Id} not found.");
            }
        }
        public void Add(ToDoItem toDoItem)
        {
            if (toDoItem == null)
            {
                throw new ArgumentNullException(nameof(toDoItem), "ToDo item cannot be null.");
            }

            _context.Add(toDoItem);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {

            ToDoItem? item = _context.Find<ToDoItem>(id);

            if(item == null)
            {
                throw new ArgumentException("Invalid ID.", nameof(id));

            }

            _context.Remove(item);

            _context.SaveChanges();
        }

    }
}
