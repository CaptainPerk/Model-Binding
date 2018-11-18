﻿using Microsoft.AspNetCore.Mvc;
using MvcModels.Models;
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

        public IActionResult Index(int? id)
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

        public ViewResult DisplaySummary([Bind(Prefix = nameof(Person.HomeAddress))]AddressSummary summary) => View(summary);
    }
}
