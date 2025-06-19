using Microsoft.EntityFrameworkCore;
using ToDoList.DTO;

namespace ToDoList.Data
{
    public class ToDoDataContext:DbContext
    {

        public ToDoDataContext(DbContextOptions<ToDoDataContext> ops):base(ops)
        {
            
        }


        public DbSet<ToDoItem> toDoItems { get; set; }
        public DbSet<UserAccount> userAccounts { get; set; }

    }
}
