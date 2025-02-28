using System.Linq;

namespace mission8.Models
{
    public interface ITaskRepository
    {
        IQueryable<TaskAppModel> Tasks { get; }
        void AddTask(TaskAppModel task);
        void UpdateTask(TaskAppModel task);
        void DeleteTask(int id);
    }
}
