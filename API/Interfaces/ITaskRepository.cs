namespace API.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<Models.Task>> GetAllTasksAsync();
        Task<Models.Task> GetTaskByIdAsync(int id);
        Task<Models.Task> CreateTaskAsync(Models.Task task);
        Task<bool> UpdateTaskAsync(Models.Task task);
        Task<bool> DeleteTaskAsync(int id);
        //Task<bool> SaveChangesAsync();
    }
}
