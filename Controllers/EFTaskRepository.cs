using System.Linq;

namespace mission8.Models
{
    public class EFTaskRepository : ITaskRepository
    {
        private TaskDbContext _context;

        public EFTaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public IQueryable<TaskModel> Tasks => _context.Tasks;

        public void AddTask(TaskModel task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(TaskModel task)
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
