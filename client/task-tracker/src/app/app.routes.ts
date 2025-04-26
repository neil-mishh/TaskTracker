import { Routes } from '@angular/router';
import { TaskListComponent } from './modules/task-list/task-list.component';
import { TaskFormComponent } from './modules/task-form/task-form.component';

export const routes: Routes = [
    {path: 'tasks', component: TaskListComponent},
    {path: 'edit/:id', component: TaskFormComponent}
];
