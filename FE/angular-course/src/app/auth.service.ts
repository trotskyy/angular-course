import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private httpClient: HttpClient) { }

  public login(login: string, pass: string): Observable<any> {
    const moel: SignInModel = {
      userName: login,
      password: pass
    };

    return this.httpClient.post('api/auth/sign-in', moel);
  }
}

export interface SignInModel {
  userName: string;
  password: string;
}
