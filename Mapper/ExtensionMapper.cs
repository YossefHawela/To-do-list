using System.Collections.ObjectModel;
using ToDoList.DTO;

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
                CreationTime = item.creationTime,
                DeadLineTime = item.deadLineTime,
                CompletionTime = item.completionTime
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
                creationTime = model.CreationTime ?? DateTime.Now,
                deadLineTime = model.DeadLineTime ?? DateTime.Now.AddDays(1), // Default to one day after creation,
                completionTime = model.CompletionTime
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
    }
}
