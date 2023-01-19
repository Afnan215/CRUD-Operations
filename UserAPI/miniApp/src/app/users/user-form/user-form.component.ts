import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { UsersService } from '../users.service';
import { User } from 'src/app/shared/user.model';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html',
  styleUrls: ['./user-form.component.css']
})
export class UserFormComponent implements OnInit {

  // @Input() userForm: FormGroup;

  constructor(public userService: UsersService) { }

  ngOnInit(): void {
  }

  submit(form:NgForm)
  {
    if(this.userService.userData.id == null)
    {
      this.insertUser(form);
    }
    else{
      this.updateUser(form);
    }
  }

  insertUser(myform:NgForm)
  {
    this.userService.addUser().subscribe(res => {
      this.resetForm(myform);
      this.refreshData();
      console.log('Save Success');
    }, error => {
      console.log(error);
    });
  }

  updateUser(myform:NgForm)
  {
    this.userService.updateUser().subscribe(res => {
      this.resetForm(myform);
      this.refreshData();
      console.log('Update Success');
    }, error => {
      console.log(error);
    });
  }

  resetForm(myform:NgForm)
  {
    myform.form.reset();
    this.userService.userData = new User();
  }

  refreshData()
  {
    this.userService.getUser().subscribe(response => {
      this.userService.userList = response;
    });
  }

}


