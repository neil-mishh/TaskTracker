import { Component } from '@angular/core';
import { Task } from '../../interfaces/task';
import { TaskService } from '../../services/task.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './task-form.component.html',
  styleUrl: './task-form.component.css'
})
export class TaskFormComponent {
  newTask: Task = {
    id: 0,
    name: '',
    description: '',
    createdAt: new Date().toISOString(),
    dueDate: '',
    isCompleted: false,
    priority: '',
    userId: 0
  }

  constructor(private taskService: TaskService, private router: Router){}

  onSubmit(){
    this.taskService.createTask(this.newTask).subscribe({
      next: () => {
        alert('Task created successfully');
        this.router.navigate(['/tasks']);
      },
      error: err => console.error('Failed to create task: ' + err)
    });
  }
}
