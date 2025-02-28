using System.Collections.Generic;
using mission8.Models;

public interface ITaskRepository
{
    IQueryable<TaskAppModel> Tasks { get; }
    void AddTask(TaskAppModel task);
    void UpdateTask(TaskAppModel task);
    void DeleteTask(int id);

    // Add this method
    IEnumerable<TaskAppModel> GetAllTasks();
    IEnumerable<Category> GetAllCategories(); // Add this method

    
    
        TaskAppModel GetTaskById(int id);
    


}
