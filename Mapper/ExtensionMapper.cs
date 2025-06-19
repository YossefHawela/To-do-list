using BCrypt.Net;
using System.Collections.ObjectModel;
using System.Security.Claims;
using ToDoList.DTO;
using ToDoList.Models;


namespace ToDoList.Mapper
{
    public static class ExtensionMapper
    {
        public static ToDoList.Models.ToDoModel ToModel(this ToDoList.DTO.ToDoItem item)
        {
            return new ToDoList.Models.ToDoModel
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted,
                CreationTime = item.CreationTime,
                DeadLineTime = item.DeadLineTime,
                CompletionTime = item.CompletionTime
            };
        }
        public static ToDoList.DTO.ToDoItem ToDto(this ToDoList.Models.ToDoModel model)
        {
            return new ToDoList.DTO.ToDoItem
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsCompleted = model.IsCompleted,
                CreationTime = model.CreationTime ?? DateTime.Now,
                DeadLineTime = model.DeadLineTime ?? DateTime.Now.AddDays(1), // Default to one day after creation,
                CompletionTime = model.CompletionTime,
                UserId = model.UserId
            };
        }

        public static ICollection<ToDoItem> ToModelCollection(this ICollection<ToDoList.Models.ToDoModel> models)
        {
            var items = new Collection<ToDoItem>();
            foreach (var model in models)
            {
                items.Add(model.ToDto());
            }
            return items;
        }

        public static ICollection<ToDoList.Models.ToDoModel> ToDtoCollection(this ICollection<ToDoItem> items)
        {
            var models = new Collection<ToDoList.Models.ToDoModel>();
            foreach (var item in items)
            {
                models.Add(item.ToModel());
            }
            return models;
        }

        public static IEnumerable<ToDoList.Models.ToDoModel> ToModelCollection(this IEnumerable<ToDoItem> items)
        {
            var models = new Collection<ToDoList.Models.ToDoModel>();
            foreach (var item in items)
            {
                models.Add(item.ToModel());
            }
            return models;
        }

        public static IEnumerable<ToDoItem> ToDtoCollection(this IEnumerable<ToDoList.Models.ToDoModel> models)
        {
            var items = new Collection<ToDoItem>();
            foreach (var model in models)
            {
                items.Add(model.ToDto());
            }
            return items;
        }

        public static UserAccount ToUserDTO(this ToDoList.Models.RegisterAccountModel model,bool isPasswordHashed = true)
        {

            // hash the password before saving it to the database

            DateTime creationTime = DateTime.UtcNow;

            var hashedPassword = model.Password; // Default to the plain password if hashing is not required

            if (isPasswordHashed)
            {
                 hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password); // Generates salt + hashes

            }




            return new UserAccount
            {
                UserName = model.UserName,
                Password = hashedPassword,
                Email = model.Email,
                CreatedAt = creationTime
            };
        }

        public static LoginAccountModel ValidatePassword(this LoginAccountModel LoginModel,UserAccount userAccount,bool isPasswordHashed = true)
        {

            bool isValid = LoginModel.Password == userAccount.Password;

            if (userAccount != null && !string.IsNullOrEmpty(userAccount.Password) && !string.IsNullOrEmpty(LoginModel.Password)&&isPasswordHashed)
            {

                isValid = BCrypt.Net.BCrypt.Verify(LoginModel.Password,userAccount.Password);
            }


            return new LoginAccountModel
            {
                UserNameOrEmail = LoginModel.UserNameOrEmail,
                Password = LoginModel.Password,
                isValid = isValid
            };
        }
        public static ToDoList.Models.UserAccountModel ToUserModel(this UserAccount dto)
        {
            return new ToDoList.Models.UserAccountModel
            {
                ID = dto.Id,
                UserName = dto.UserName,
                Email = dto.Email,
            };
        }
    }
}
