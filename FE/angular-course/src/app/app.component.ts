import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';

  public selectedTaskId: number;

  constructor(htttClient: HttpClient) {
    // htttClient.get('http://localhost:3035/api/resource')
    //   .subscribe(resources => {
    //     console.log(resources);
    //   }, err => {
    //     console.error(err);
    //   });
    // htttClient.post('http://localhost:3035/api/resource', {}).subscribe();

    // htttClient.get('api/resource').subscribe();
    // htttClient.post('api/resource', {}).subscribe();
  }

  public onSelect(taskId: number) {
    this.selectedTaskId = taskId;
  }
}
