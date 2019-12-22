import { Component, OnInit, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Task } from '../model/task';

@Component({
  selector: 'app-task',
  templateUrl: './task.component.html',
  styleUrls: ['./task.component.css']
})
export class TaskComponent implements OnInit {

  @Input()
  public set taskId(value: number) {
    this.load(value);
  }
  public task: Task;

  public get totalHours(): number {
    return !this.task
      ? undefined
      : this.task.subTasks
        .map(st => st.estimateHours)
        .reduce((acc, v) => acc + v, 0);
  }

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    
  }

  private load(taskId: number) {
    this.httpClient.get<Task>('api/tasks/' + taskId)
      .subscribe(task => {
        this.task = task;
      });
  }
}
