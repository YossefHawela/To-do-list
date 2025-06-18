using System.Diagnostics;
using System.Net.WebSockets;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;
using static ToDoList.Mapper.ExtensionMapper;
using System.Linq;
using ToDoList.DTO;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Data.DataConnector _dataConnector;
        private readonly UIDataSorage _uiDataSorage;

        public HomeController(ILogger<HomeController> logger, Data.DataConnector dataConnector,UIDataSorage uIDataSorage)
        {
            _logger = logger;
            _dataConnector = dataConnector;
            _uiDataSorage = uIDataSorage;
        }

        public IActionResult Index()
        {
            var ToDoModelCollection = _dataConnector.ToDoItems.ToModelCollection();

            var ToDoModelsInEditMode = _uiDataSorage.ToDoItemsInEditMode.ToModelCollection();

            var _EditModeitems = from EditModeItem in ToDoModelsInEditMode
                                            let item = ToDoModelCollection.First(m => m.Id == EditModeItem.Id)
                                            select item;




            foreach (var item in _EditModeitems)
            {
                item.inEditMode = true;
            }

            _uiDataSorage.ClearEditModeList();


            return View(ToDoModelCollection);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
