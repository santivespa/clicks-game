import { Injectable } from '@angular/core';

import { Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MsgUsersService {



  private _refreshUsers = new Subject<any[]>();
  msgRefreshUsers$ = this._refreshUsers.asObservable();

  msgRefreshUsers(users: any[]) {
    this._refreshUsers.next(users);
  }


  private _successLogin = new Subject < string>();
  successLogin$ = this._successLogin.asObservable();

  msgSuccessLogin(userName: string) {
    this._successLogin.next(userName);
  }
  
}
