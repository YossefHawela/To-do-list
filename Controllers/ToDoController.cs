using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Mapper;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoController:Controller
    {
        private readonly Data.DataConnector _dataConnector;

        private readonly UIDataSorage _uIDataSorage;
        public ToDoController(DataConnector dataConnector,UIDataSorage uIDataSorage)
        {
            _dataConnector = dataConnector;
            _uIDataSorage = uIDataSorage;
        }


        [HttpPost]
        [Authorize(AuthenticationSchemes = "ToDoAuthenCookie")]

        public IActionResult Add(ToDoModel toDoModel)
        {
            toDoModel.CreationTime = DateTime.Now;

            _dataConnector.Add(toDoModel.ToDto());

            return RedirectToAction("Index", "Home", null);
        }

        [Authorize(AuthenticationSchemes = "ToDoAuthenCookie")]

        public IActionResult SetCompleted(ToDoModel toDoModel)
        {
            toDoModel.IsCompleted = true;

            toDoModel.CompletionTime = DateTime.Now;

            _dataConnector.Update(toDoModel.ToDto());

            return RedirectToAction("Index", "Home", null);

        }


        [Authorize(AuthenticationSchemes = "ToDoAuthenCookie")]
        public IActionResult SetUnCompleted(ToDoModel toDoModel)
        {
            toDoModel.IsCompleted = false;
            _dataConnector.Update(toDoModel.ToDto());
            return RedirectToAction("Index", "Home", null);
        }


        [Authorize(AuthenticationSchemes = "ToDoAuthenCookie")]

        public IActionResult Delete(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid ID.");
            }
            _dataConnector.Delete(id);
            return RedirectToAction("Index", "Home", null);
        }

        [Authorize(AuthenticationSchemes = "ToDoAuthenCookie")]
            
        public IActionResult EnterEditMode(ToDoModel toDoModel)
        {

            _uIDataSorage.AddItemToEditModeList(toDoModel.ToDto());

            return RedirectToAction("Index", "Home", null);

        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "ToDoAuthenCookie")]

        public IActionResult Update(ToDoModel toDoModel)
        {

            _dataConnector.Update(toDoModel.ToDto());

            return RedirectToAction("Index", "Home", null);

        }
    }
}
