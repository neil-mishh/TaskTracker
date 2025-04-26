import { Routes } from '@angular/router';
import { TaskListComponent } from './modules/task-list/task-list.component';
import { TaskFormComponent } from './modules/task-form/task-form.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    {path: 'tasks', component: TaskListComponent},
    {path: 'tasks/new', component: TaskFormComponent},
    {path: 'tasks/edit/:id', component: TaskFormComponent},
    {path: 'home', component: HomeComponent}
];
