import { Component, OnInit } from '@angular/core';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  public showPopUp: boolean;

  public login: string;
  public password: string;

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  public onClick() {
    this.showPopUp = true;
  }

  public onHideClick() {
    this.showPopUp = false;
  }

  public onFormClick(event: MouseEvent) {
    event.stopPropagation();
  }

  public invalid: boolean;

  public onOk() {
    this.authService.login(this.login,
      this.password)
    .subscribe(() => {
      this.showPopUp = false;
    },
      err => {
        if (err.status == 400) {
          this.invalid = true;
        }
      });
  }
}



