import { Component, OnInit } from '@angular/core';
import { MainHubService } from '../../_services/mainHub.service';
import { MsgClicksService } from '../../_services/msgClicks.service';

@Component({
  selector: 'main-counter',
  templateUrl: './main-counter.component.html',
  styleUrls: ['./main-counter.component.css']
})
export class MainCounterComponent implements OnInit  {

  count: number;

  constructor(private mainHub: MainHubService, private msgClicksService: MsgClicksService) {
  
  }

  ngOnInit(): void {

    this.msgClicksService.msgRefreshClicks$.subscribe(
      (message) => (this.refreshCount(message))
    );


  }

  refreshCount(count: any) {
    this.count = count;
  }

  click() {
    this.mainHub.addClick();
  }

}
