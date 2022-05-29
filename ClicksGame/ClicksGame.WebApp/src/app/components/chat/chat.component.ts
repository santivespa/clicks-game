import { Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { MsgMessagesService } from '../../_services/msgMessages.service ';
import { MainHubService } from '../../_services/mainHub.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MsgUsersService } from '../../_services/msgUsers.service';


@Component({
  selector: 'chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {

  messages: any[];
  form: FormGroup;
  currentUserName: string;
  


  constructor(private mainHub: MainHubService,private msgMessagesService: MsgMessagesService, private msgUserService: MsgUsersService,private fb: FormBuilder) { }

  ngOnInit(): void {
    this.buildForm();
    this.msgMessagesService.msgRefreshMessages$.subscribe(
      (message) => (this.refreshMessages(message))
    );

    this.msgUserService.successLogin$.subscribe(
      (message) => (this.successLogin(message))
    );

  }


  buildForm() {
    this.form = this.fb.group({
      text: ['', Validators.required],
    });
  }

  postMessage() {

    if (this.form.valid) {
      let value = this.form.value;
      this.mainHub.postMessage(value);

      this.form.reset();
    }
  }

  refreshMessages(messages) {
    this.messages = messages;

  }


  successLogin(userName: string) {
    this.currentUserName = userName;
  }



  //automatico scroll

  @ViewChild('scrollframe', { static: false }) scrollFrame: ElementRef;
  @ViewChildren('item') itemElements: QueryList<any>;
  private scrollContainer: any;

  ngAfterViewInit() {
    this.scrollContainer = this.scrollFrame.nativeElement;
    this.itemElements.changes.subscribe(_ => this.onItemElementsChanged());
  }

  private onItemElementsChanged(): void {
    this.scrollToBottom();
  }

  private scrollToBottom(): void {
    this.scrollContainer.scroll({
      top: this.scrollContainer.scrollHeight,
      left: 0,
      behavior: 'smooth'
    });
  }


}
