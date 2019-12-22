import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TaskListItem } from '../model/task-list-item';

@Component({
    selector: 'app-task-list',
    templateUrl: './task-list.component.html',
    styleUrls: [ 'task-list.component.css' ]
})
export class TaskListComponent implements OnInit {

    @Output()
    public select = new EventEmitter<number>();

    public listItem: TaskListItem;

    public taskList: TaskListItem[];
    private httpClient: HttpClient;

    constructor(httpClient: HttpClient) {
        this.httpClient = httpClient;
    }

    ngOnInit() {
        this.httpClient.get<TaskListItem[]>('api/tasks')
            .subscribe(taskList => {
                this.taskList = taskList;
                this.listItem = taskList[0];
                console.log(this.taskList);
            }, err => {
                if (err.status === 401) {
                    alert('Log in!');
                }
            });
    }

    public onClick(taskId: number) {
        this.select.emit(taskId);
    }
}
