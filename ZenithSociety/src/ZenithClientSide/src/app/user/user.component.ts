import { Component, OnInit, Input } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  name: String;
  pass: String;
  constructor(private UserService: UserService) { }

  ngOnInit() {
    //this.UserService.login(this.name, this.pass).Subcribe(
    //);
  }
  Login(name, pass): void {
    console.log(name);
    console.log(pass);
  }
  user = new User();
  get userInfo() {
        return JSON.stringify(this.user);
    }
}
