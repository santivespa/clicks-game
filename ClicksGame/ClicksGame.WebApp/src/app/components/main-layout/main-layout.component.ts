import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.css']
})
export class MainLayoutComponent implements OnInit {

  currentUserName: string;

  constructor() { }

  ngOnInit(): void {
  }


  setCurrentUser(userName:string) {
    this.currentUserName = userName;
  }

}
