using Microsoft.AspNetCore.Mvc;
using mission8.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace mission8.Controllers
{
    public class TaskController : Controller
    {
        private ITaskRepository _repo;

        public TaskController(ITaskRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var tasks = _repo.Tasks.Include(t => t.Category)
                                   .Where(t => !t.Completed)
                                   .ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTask(TaskAppModel task)
        {
            if (ModelState.IsValid)
            {
                _repo.AddTask(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            return View(task);
        }

        [HttpPost]
        public IActionResult Edit(TaskAppModel task)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateTask(task);
                return RedirectToAction("Index");
            }
            return View(task);
        }

        public IActionResult Delete(int id)
        {
            _repo.DeleteTask(id);
            return RedirectToAction("Index");
        }

        public IActionResult MarkComplete(int id)
        {
            var task = _repo.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task != null)
            {
                task.Completed = true;
                _repo.UpdateTask(task);
            }
            return RedirectToAction("Index");
        }
    }
}
