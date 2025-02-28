using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mission8.Models;
using System.Linq;

namespace mission8.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskRepository _repo;

        public HomeController(ITaskRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var tasks = _repo.Tasks.Include(t => t.Category).ToList();
            return View(tasks);
        }



    }
}
