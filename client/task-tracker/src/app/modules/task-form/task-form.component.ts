import { Component, OnInit } from '@angular/core';
import { Task } from '../../interfaces/task';
import { TaskService } from '../../services/task.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'
import { subscribe } from 'diagnostics_channel';

@Component({
  selector: 'app-task-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './task-form.component.html',
  styleUrl: './task-form.component.css'
})
export class TaskFormComponent implements OnInit{
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

  constructor(
    private taskService: TaskService, 
    private router: Router,
    private route: ActivatedRoute
  ){}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.taskService.getTaskByID(+id).subscribe({
        next: task => this.newTask = task
      })
    }
  }

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
