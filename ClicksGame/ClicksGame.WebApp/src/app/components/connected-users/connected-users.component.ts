import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MsgUsersService } from '../../_services/msgUsers.service';
import { MainHubService } from '../../_services/mainHub.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MsgInvitationssService } from '../../_services/msgInvitations.service';



@Component({
  selector: 'connected-users',
  templateUrl: './connected-users.component.html',
  styleUrls: ['./connected-users.component.css']
})
export class ConnectedUsersComponent implements OnInit {

  users: any[];
  form: FormGroup;
  currentUserName: string;

  @Output() emitterSuccessLogin: EventEmitter<string>;


  constructor(private mainHub: MainHubService, private msgUserService: MsgUsersService,private msgInvitationsService: MsgInvitationssService, private fb: FormBuilder) {
    this.emitterSuccessLogin = new EventEmitter();
  }

  ngOnInit(): void {
    this.buildForm();

    this.msgUserService.msgRefreshUsers$.subscribe(
      (message) => (this.refreshUsers(message))
    );


    this.msgUserService.successLogin$.subscribe(
      (message) => (this.successLogin(message))
    );

    this.msgInvitationsService.msgInvitationReceived$.subscribe(
      (message) => (this.invitationReceived(message))
    );


    this.msgInvitationsService.msgInvitationSended$.subscribe(
      () => (this.invitationSended())
    );


  }

  buildForm() {
    this.form = this.fb.group({
      userName: ['', Validators.required],
    });
  }


  enter() {
    if (this.form.valid) {
      let value = this.form.value;
     this.mainHub.enter(value.userName);
   
      this.form.reset();
    }
  }

  refreshUsers(users:any) {
    this.users = users;
  }

  successLogin(userName: string) {
    this.currentUserName = userName;
    this.emitterSuccessLogin.emit(userName);

  }



  inviteUser(userName: string) {
    if (userName != this.currentUserName) {
      this.mainHub.inviteUser(userName);
    }
  }



  invitationReceived(userName:any) {
    console.log("invitacion recivida de "+userName);
  }

  invitationSended() {
    console.log("invitacion enviada")
  }
}
