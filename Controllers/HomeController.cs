using Microsoft.AspNetCore.Mvc;
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
            var tasks = _repo.Tasks?.Where(t => !t.Completed).ToList() ?? new List<TaskAppModel>();
            return View(tasks); 
        }
    }
}
