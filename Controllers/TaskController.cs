using Microsoft.AspNetCore.Mvc;
using mission8.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace mission8.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskRepository _repo;

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
        public IActionResult Create()
        {
            ViewBag.Categories = _repo.GetAllCategories(); // Ensure this matches the interface
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaskAppModel task)
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
    var task = _repo.GetTaskById(id);
    if (task == null)
    {
        return NotFound();
    }

            var categories = _repo.GetAllCategories().ToList();
            // Ensure categories is not null

            var editTask = new EditTask
    {
        TaskId = task.TaskId,
        TaskName = task.TaskName,
        DueDate = task.DueDate,
        Quadrant = task.Quadrant,
        CategoryId = task.CategoryId,
        Completed = task.Completed,
        Categories = _repo.GetAllCategories().ToList() // Pass categories to the view
            };

    return View(editTask);
}



        [HttpPost]
        public IActionResult Edit(EditTask editTask)
        {
            if (ModelState.IsValid)
            {
                var task = _repo.GetTaskById(editTask.TaskId);
                if (task == null)
                {
                    return NotFound();
                }

                // ✅ Update properties
                task.TaskName = editTask.TaskName;
                task.DueDate = editTask.DueDate;
                task.Quadrant = editTask.Quadrant;
                task.CategoryId = editTask.CategoryId;
                task.Completed = editTask.Completed;

                _repo.UpdateTask(task);
                return RedirectToAction("Index");
            }

            return View(editTask); // Return the form with validation messages
        }


        public IActionResult Delete(int id)
        {
            _repo.DeleteTask(id);
            return RedirectToAction("Index");
        }

        public IActionResult CompleteTask(int id)
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
