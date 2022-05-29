import { Injectable } from '@angular/core';

import { Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class MsgClicksService {


  private _refreshClicks = new Subject<any[]>();
  msgRefreshClicks$ = this._refreshClicks.asObservable();

  msgRefreshClicks(Clicks: any[]) {
    this._refreshClicks.next(Clicks);
  }


}
