import { Component, OnInit} from '@angular/core';
import { Event } from '../event';
import { EventService } from '../event.service';

@Component({
  selector: 'app-event',
  templateUrl: './event.component.html',
  styleUrls: ['./event.component.css']
})
export class EventComponent implements OnInit {
  results: Array<Event>;
  currentDate: Date;
  endDate: Date;
  events = new Map<string, Array<Event>>()

  timeFormat: string;
  dateFormat: string;

  constructor(private EventService: EventService) { }

  ngOnInit() {

    this.EventService.getAll().subscribe(
      data => { this.results = data; 
                this.results.sort(function(a,b){
                return new Date(a.startDate).getTime() - new Date(b.startDate).getTime();
                });},
      error => console.log(error)
    );

    this.currentDate = new Date();

    this.timeFormat = "h:mm a";
    this.dateFormat = "EEEE MMMM dd, yyyy";

    // var curr = new Date; // get current date
    // var first = curr.getDate() - curr.getDay(); // First day is the day of the month - the day of the week
    // var last = first + 6; // last day is the first day + 6

    // var firstday = new Date(curr.setDate(first));
    // var lastday = new Date(curr.setDate(firstday.getDate()+6)).toUTCString();

  }

}
