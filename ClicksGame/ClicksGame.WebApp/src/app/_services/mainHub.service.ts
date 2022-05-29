import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import * as signalR from '@microsoft/signalr';
import { environment } from '../../environments/environment';
import { Subject } from 'rxjs';
import { MsgUsersService } from './msgUsers.service';
import { MsgMessagesService } from './msgMessages.service ';
import { MsgClicksService } from './msgClicks.service';
import { MsgInvitationssService } from './msgInvitations.service';


@Injectable({
  providedIn: 'root'
})
export class MainHubService {


  connection = new signalR.HubConnectionBuilder()
    .configureLogging(signalR.LogLevel.Information)
    .withUrl(environment.baseUrl + 'mainHub')
    .build();


  constructor(
    private msgMessagesService: MsgMessagesService,
    private msgUserService: MsgUsersService,
    private msgClicksService: MsgClicksService,
    private msgInvitationservice: MsgInvitationssService  ) {
    this.startConnection();
  }


  startConnection() {
    this.connection.start().then(x => {
      console.log("Connected to SignalR!");
     /* this.enter('santivespa');*/
    }).catch(function (err) {
      return console.error(err.toString());
    });

    this.connection.on("DisplayMessages", (messages) => {
      this.msgMessagesService.msgRefreshMessages(messages);
    });

    this.connection.on("DisplayUsers", (users) => {
      this.msgUserService.msgRefreshUsers(users);
    });

    this.connection.on("SuccessLogin", (userName) => {
      this.msgUserService.msgSuccessLogin(userName);
    });

    this.connection.on("GetCount", (count) => {
      this.msgClicksService.msgRefreshClicks(count);
    });

    this.connection.on("InvitationReceived", (userName) => {
    
      this.msgInvitationservice.invitationReceived(userName);
    });

    this.connection.on("InvitationSended", () => {
      this.msgInvitationservice.msgInvitationSended();
    });
  }



  enter(text: string) {
    this.connection.invoke("Login", text)
      .catch(function (err) {
        return console.error(err.toString());
      });
  }

  postMessage(message: any) {
    this.connection.invoke("PostMessage", message)
      .catch(function (err) {
        return console.error(err.toString());
      });
  }


  addClick() {
    this.connection.invoke("Click")
      .catch(function (err) {
        return console.error(err.toString());
      });
  }


  inviteUser(userName: string) {
    this.connection.invoke("InviteUser", userName)
      .catch(function (err) {
        return console.error(err.toString());
      });
  }

  addRanking(r:any) {
    this.connection.invoke("AddRanking", r)
      .catch(function (err) {
        return console.error(err.toString());
      });
  }
}
