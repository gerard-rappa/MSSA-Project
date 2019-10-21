using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TacoBoutIt.Models;

namespace TacoBoutIt.Controllers
{
    public class MapController : Controller
    {
        private IMemeRepository repository;

        public MapController(IMemeRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index()
        {
            return View(repository.Memes);
        }
    }
}