using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
            if (task == null)
            {
                return null;
            }
            _context.Tasks.Add(task);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return task;
            }
            return null;
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync()
        {
            var tasks = await _context.Tasks.ToListAsync();
            if (tasks == null || tasks.Count == 0)
            {
                return null;
            }
            return tasks;
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            var task = await _context.Tasks.FirstOrDefaultAsync(task => task.Id == id);
            if (task == null)
            {
                return null;
            }
            return task;
        }

        public async Task<TaskItem> UpdateTaskAsync(TaskItem task)
        {
            if (task == null)
            {
                return null;
            }

            var existingTask = await GetTaskByIdAsync(task.Id);
            if (existingTask == null)
            {
                return null;
            }

            _context.Entry(existingTask).CurrentValues.SetValues(task);

            var result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return task;
            }
            else
            {
                return null;
            }
        }
    }
}
