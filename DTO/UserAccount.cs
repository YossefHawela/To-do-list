using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.DTO
{

    [Table("Users")]
    public class UserAccount
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required,EmailAddress, ]

        public string Email { get; set; } = string.Empty;
        [Required, MinLength(8)]
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    }
}
