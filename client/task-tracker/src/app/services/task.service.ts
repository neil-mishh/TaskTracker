import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Task } from '../interfaces/task';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private baseURL = 'http://localhost:5258/';

  constructor(private http: HttpClient) { }

  getAllTasks(): Observable<Task[]>{
    return this.http.get<Task[]>(this.baseURL + 'Task');
  }

  createTask(task: Task){
    return this.http.post(this.baseURL + 'task/create', task)
  }

  updateTask(task: Task){
    return this.http.post(this.baseURL + 'task/update', task)
  }

  getTaskByID(id: number): Observable<Task> {
    return this.http.get<Task>(this.baseURL + 'task/' + id)
  }

}
