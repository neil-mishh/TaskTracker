using API.Interfaces;

namespace API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public Task<Models.Task> CreateTaskAsync(Models.Task task)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Models.Task>> GetAllTasksAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Models.Task> GetTaskByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTaskAsync(Models.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
