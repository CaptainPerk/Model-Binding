using Microsoft.AspNetCore.Mvc;
using MvcModels.Models.Interfaces;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(int id) => View(_repository[id]);
    }
}
