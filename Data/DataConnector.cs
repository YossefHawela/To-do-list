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
        public void Add<T>(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "ToDo item cannot be null.");
            }

            _context.Add(item);

            _context.SaveChanges();
        }

        public bool IsUserNameAvailable(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("User name cannot be null or empty.", nameof(userName));
            }
            return !_context.userAccounts.Any(u => u.UserName.ToLower() == userName.ToLower());
        }

        public bool IsEmailAvailable(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }
            return !_context.userAccounts.Any(u => u.Email.ToLower() == email.ToLower());
        }

        public UserAccount? GetUserByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }
            return _context.userAccounts.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }

        public UserAccount? GetUserByUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("User name cannot be null or empty.", nameof(userName));
            }
            return _context.userAccounts.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());
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
