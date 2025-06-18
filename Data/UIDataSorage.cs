using ToDoList.DTO;

namespace ToDoList.Data
{
    public class UIDataSorage
    {
        private List<DTO.ToDoItem> toDoItemsInEditMode { get; set; } = new List<DTO.ToDoItem>(); // a list of items currently in edit mode

        public IReadOnlyList<ToDoItem> ToDoItemsInEditMode => toDoItemsInEditMode;

        public void AddItemToEditModeList(ToDoItem item)
        {
            var todoItem = ToDoItemsInEditMode.FirstOrDefault(i => i.Id == item.Id);

            if(todoItem == null)
            {
                toDoItemsInEditMode.Add(item);
            }

        }
        public void RemoveItemFromEditModeList(ToDoItem item)
        {
            var todoItem = ToDoItemsInEditMode.FirstOrDefault(i => i.Id == item.Id);

            if (todoItem != null)
            {
                toDoItemsInEditMode.Remove(todoItem);
            }
        }

        public void ClearEditModeList()
        {
            toDoItemsInEditMode.Clear();
        }
    }
}
