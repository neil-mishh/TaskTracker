import { Component, OnInit } from '@angular/core';
import { Task } from '../../interfaces/task';
import { TaskService } from '../../services/task.service';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css'
})
export class TaskListComponent implements OnInit{

  tasks: Task[] = [];

  constructor(private taskService: TaskService){}

  ngOnInit(): void {
    this.taskService.getAllTasks().subscribe({
      next: value => this.tasks = value,
      error: err => console.log('Observable emitted an error: ' + err),
      complete: () => console.log('Observable emitted the complete notification')
    });
  }

}
