import { Component, OnInit } from '@angular/core';
import { Task } from '../../interfaces/task';
import { TaskService } from '../../services/task.service';
import { CommonModule } from '@angular/common';  // Import CommonModule instead of BrowserModule
import { Router } from '@angular/router';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css'
})
export class TaskListComponent implements OnInit{

  tasks: Task[] = [];
  selectedTask: Task | null = null;

  constructor(private taskService: TaskService, private router: Router){}

  ngOnInit(): void {
    this.taskService.getAllTasks().subscribe({
      next: value => {
        console.log(value);
        this.tasks = value;
      },
      error: err => console.log('Observable emitted an error: ' + err),
      complete: () => console.log('Observable emitted the complete notification')
    });
  }

  onSelect(task: Task){
    this.selectedTask = task;
  }

  editTask(){
    if(this.selectedTask != null){
      this.router.navigate(['/edit', this.selectedTask.id]);
    }
  }
}
