using System.Linq;
using Microsoft.EntityFrameworkCore;
using mission8.Models;

namespace mission8.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private AppDbContext _context; // Fixed inconsistent DbContext name

        public EFTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<TaskAppModel> Tasks => _context.Tasks; // Ensure model consistency

        public void AddTask(TaskAppModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(TaskAppModel task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.TaskId == id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}
