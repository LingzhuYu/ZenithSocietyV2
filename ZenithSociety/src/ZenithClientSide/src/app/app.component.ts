import { Component } from '@angular/core';
import { EventService } from "./event.service";
import { EventComponent } from "./event/event.component";
import { UserService } from "./user.service";
import { UserComponent } from "./user/user.component";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [EventService, UserService]
})

export class AppComponent {
  title = 'Zenith Society';
}
