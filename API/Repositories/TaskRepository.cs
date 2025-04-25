using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public async Task<TaskItem> CreateTaskAsync(TaskItem task)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return tasks;
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid task ID");
            }
            var task = await _context.Tasks.FirstOrDefaultAsync(task => task.Id == id);
            if (task == null)
            {
                throw new KeyNotFoundException($"Task with ID {id} not found");
            }
            return task;
        }

        public async Task<bool> UpdateTaskAsync(TaskItem task)
        {
            if (task == null)
            {
                return false;
            }

            var existingTask = await GetTaskByIdAsync(task.Id);
            if (existingTask == null)
            {
                return false;
            }
            existingTask.Name = task.Name;
            existingTask.Description = task.Description;
            existingTask.DueDate = task.DueDate;
            existingTask.IsCompleted = task.IsCompleted;
            existingTask.Priority = task.Priority;
            existingTask.CreatedAt = task.CreatedAt;
            existingTask.UserId = task.UserId;

            _context.Tasks.Update(existingTask);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
