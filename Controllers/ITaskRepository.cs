using System.Linq;

namespace mission8.Models
{
    public interface ITaskRepository
    {
        IQueryable<TaskModel> Tasks { get; }
        void AddTask(TaskModel task);
        void UpdateTask(TaskModel task);
        void DeleteTask(int id);
    }
}
