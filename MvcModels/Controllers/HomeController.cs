using Microsoft.AspNetCore.Mvc;
using MvcModels.Models;
using MvcModels.Models.Interfaces;
using System.Collections.Generic;

namespace MvcModels.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index([FromQuery]int? id)
        {
            Person person;
            if (id.HasValue && (person = _repository[id.Value]) != null)
            {
                return View(person);
            }

            return NotFound();
        }

        public ViewResult Create() => View(new Person());

        [HttpPost]
        public ViewResult Create(Person model) => View("Index", model);

        public ViewResult DisplaySummary([Bind(nameof(AddressSummary.City), Prefix = nameof(Person.HomeAddress))]AddressSummary summary) => View(summary);

        public ViewResult Names(IList<string> names) => View(names ?? new List<string>());

        public ViewResult Address(IList<AddressSummary> addresses) => View(addresses ?? new List<AddressSummary>());

        public string Header([FromHeader(Name = "Accept-Language")] string accept) => $"Header: {accept}";
    }
}
