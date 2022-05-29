import { Injectable } from '@angular/core';

import { Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MsgInvitationssService {


  private _invitationReceived = new Subject<any>();
  msgInvitationReceived$ = this._invitationReceived.asObservable();

  invitationReceived(userName: any[]) {
    this._invitationReceived.next(userName);
  }


  private _invitationSended = new Subject<void>();
  msgInvitationSended$ = this._invitationSended.asObservable();

  msgInvitationSended() {
    this._invitationSended.next();
  }

}
