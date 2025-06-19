using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using ToDoList.Data;
using ToDoList.DTO;
using ToDoList.Models;
using static ToDoList.Mapper.ExtensionMapper;

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


        [Authorize(AuthenticationSchemes = "ToDoAuthenCookie")]

        public IActionResult Index()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

            var ToDoModelCollection = _dataConnector.GetToDoItemsByUserId(userId).OrderBy(tdi=>tdi.CreationTime)
                .ToModelCollection();

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


        [Authorize(AuthenticationSchemes = "ToDoAuthenCookie")]

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize(AuthenticationSchemes = "ToDoAuthenCookie")]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
