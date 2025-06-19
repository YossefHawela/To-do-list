namespace ToDoList.Models
{
    public class UserAccountModel
    {
        public Guid ID { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
