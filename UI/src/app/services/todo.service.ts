import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ToDoItem } from '../models/ToDoItem';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
};

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  apiURL: string = 'https://localhost:44372/api/';
  constructor(private httpClient: HttpClient) { }

  public getAllToDoItems(){
    return this.httpClient.get<ToDoItem[]>(`${this.apiURL}todo`);
  }

  public createToDoItem(toDoItem: ToDoItem): Observable<any>{
    return this.httpClient.post<boolean>(`${this.apiURL}todo`, toDoItem, httpOptions);
  }

  public updateUser(toDoItem: ToDoItem): Observable<any>{
    return this.httpClient.put<any>(`${this.apiURL}todo`, toDoItem, httpOptions);
  }

  public deleteProfile(id: number): Observable<any>{
    return this.httpClient.delete<any>(`${this.apiURL}todo/${id}`, httpOptions);
  }
}


