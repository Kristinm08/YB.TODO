import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
      { path: 'todo/new', component: CreateToDoComponent},
  ];

@NgModule({
    imports: [RouterModule.forRoot(routes)], 
    exports: [RouterModule]
  })
  export class AppRoutingModule { }