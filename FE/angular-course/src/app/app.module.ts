import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TaskListComponent } from './task-list/task-list.component';
import { TaskComponent } from './task/task.component';
import { SubTaskComponent } from './task/sub-task/sub-task.component';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { ApiInterceptor } from 'src/interceptors/api.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    TaskListComponent,
    TaskComponent,
    SubTaskComponent,
    NavBarComponent
  ],
  imports: [
    HttpClientModule,
    FormsModule,
    CommonModule,
    BrowserModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
