import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit {
  todoitems: ToDoItem[];
  router: any;
  constructor(private todoService: ToDoService) { }

  ngOnInit(): void {
    this.todoService.getAllToDoItems().subscribe((result)=>{
      this.todoitems = result;
    });
  }

  createToDo(id: number){
    this.router.navigate(['todo/new'], { queryParams: { id }});
  }
}
