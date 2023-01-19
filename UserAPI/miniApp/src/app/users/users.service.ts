import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../shared/user.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  baseUrl = environment.apiUrl;
  userList: User[] = [];   // For Getting Data UserList

  userData: User = new User(); // For post / Inserting Data
  
  constructor(private http: HttpClient) { }

  addUser()
  {
    return this.http.post(this.baseUrl + 'Users', this.userData);
  }

  updateUser()
  {
    return this.http.put(`${this.baseUrl}` + 'Users/' + `${this.userData.id}`, this.userData);
  }

  getUser(): Observable<User[]>
  {
    return this.http.get<User[]>(this.baseUrl + 'Users');
  }

  deleteUser(id:string)
  {
    return this.http.delete(`${this.baseUrl}` + 'Users/' + id)
  }
}
