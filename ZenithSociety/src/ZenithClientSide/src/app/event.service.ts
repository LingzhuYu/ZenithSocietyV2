    import { Injectable } from '@angular/core';
    import { Http, Response } from '@angular/http';
    import 'rxjs/add/operator/map';

    @Injectable()
    export class EventService {

      constructor(private http: Http) { }

      getAll() {
        return this.http.get('http://a2.kagutsuchi.net/api/eventapi')
        .map((res: Response) => res.json());
      }
    }
