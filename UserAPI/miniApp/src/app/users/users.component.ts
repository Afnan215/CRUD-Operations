import { Component, OnInit } from '@angular/core';
import { UsersService } from './users.service';
import { User } from '../shared/user.model';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  // popover
  public popoverTitle: string = 'Select the Option';
  public popoverMessage: string = 'Delete/Cancel';

  public confirmClicked:boolean = false;
  public cancelClicked:boolean = false;

  page: number = 1;

  constructor(public userService: UsersService) { }

  ngOnInit(): void {
    this.userService.getUser().subscribe(res => {
      console.log(res);
      this.userService.userList = res;
    }, error => {
      console.log(error);
    });
  }

  updateUser(selectedUser: User)
  {
    console.log(selectedUser);
    this.userService.userData = selectedUser;
  }

  deleteUser(id:string)
  {
    if (id != null)
    {
      this.userService.deleteUser(id).subscribe(res => {
        console.log('Record deleted...');
        this.userService.getUser().subscribe(res => {
          this.userService.userList = res;
        });
      }, error => {
        console.log(error);
      });
    }        
  }

}
