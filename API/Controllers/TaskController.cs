using API.Data;
using API.Interfaces;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskRepository _taskRepository;

        public TaskController(ILogger<TaskController> logger, ITaskRepository taskRepository)
        {
            _logger = logger;
            _taskRepository = taskRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Models.Task task)
        {
            if (task == null)
            {
                return BadRequest(new {message = "Invalid task data"});
            }
            var createdTask = await _taskRepository.CreateTaskAsync(task);

            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateTask([FromBody] Models.Task task)
        //{
        //    if (task == null)
        //    {
        //        return BadRequest(new { message = "Invalid task data" });
        //    }
        //    var updatedTask = await _taskRepository.UpdateTaskAsync(task);

        //    return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, updatedTask);
        //}
    }
}
