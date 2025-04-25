using API.Interfaces;
using API.Models;
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
            if (tasks == null || !tasks.Any())
            {
                return NotFound(new { message = "No tasks found" });
            }
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskRepository.GetTaskByIdAsync(id);
            return task == null ? NotFound(new { message = $"Task with ID {id} not found" }) : Ok(task);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            if (task == null)
            {
                return BadRequest(new {message = "Invalid task data"});
            }
            var createdTask = await _taskRepository.CreateTaskAsync(task);

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, createdTask);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateTask([FromBody] TaskItem task)
        {
            var updatedTask = await _taskRepository.UpdateTaskAsync(task);
            if (updatedTask == null)
            {
                return BadRequest(new { message = "Unable to update given task" });
            }

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, updatedTask);
        }
    }
}
