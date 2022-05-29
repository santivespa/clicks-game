import { Injectable } from '@angular/core';

import { Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MsgMessagesService {


  private _refreshMessages = new Subject<any[]>();
  msgRefreshMessages$ = this._refreshMessages.asObservable();

  msgRefreshMessages(messages: any[]) {
    this._refreshMessages.next(messages);
  }


}
