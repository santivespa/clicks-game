import { Component, OnInit } from '@angular/core';
import { Observable, Subscription, timer } from 'rxjs';
import { MainHubService } from '../../_services/mainHub.service';
import { MsgClicksService } from '../../_services/msgClicks.service';
declare var $: any;

@Component({
  selector: 'game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit  {

  currentValue: number;
  points: number = 0;

  secondsLeft: number;

  timeoutID: any;

  squaresNums: 16;

  secondsToStart: number ;

  running: boolean;

  firstGame: boolean;


  hitAudioSrc = '../../../assets/audios/hit.mp3';
  failHitAudioSrc = '../../../assets/audios/fail-hit.mp3';

  audio

  silence: boolean;
  constructor(private mainHub: MainHubService) {
  
  }



  ngOnInit(): void {
    this.firstGame = true;
    this.silence= true;
  }

  startGame() {
    this.firstGame = false;
    this.secondsLeft = 10;
    this.points = 0;
    this.secondsToStart = 3;
    this.currentValue = 0;
    this.running = true;

    for (let i = 1; i <= this.secondsToStart; i++) {

      setTimeout(() => {
        this.secondsToStart--;

        if (this.secondsToStart == 0) {
          this.changeValue();

          for (let i = 1; i <= this.secondsLeft; i++) {
            setTimeout(() => {
              this.secondsLeft--;
              if (this.secondsLeft == 0) {
                this.finishGame();
              }
              
            }, i * 1000);
          }
         

        }
      }, i * 1000);
    }
  }

 


  restart() {
    this.startGame();
  }

  click(clickedValue) {
    if (this.secondsLeft > 0 && this.running && this.secondsToStart ==0) {
      if (this.currentValue == clickedValue) {
          this.playAudio(this.hitAudioSrc);
        clearTimeout(this.timeoutID);
        this.changeValue();
        this.points++;
      } else {
        this.points--;
          this.playAudio(this.failHitAudioSrc);
      } 
    
    }

  }
  playAudio(src: string) {
    if (!this.silence) {
      let audio = new Audio(src);
      /*audio.volume = 0.4;*/
      audio.play();
    }
  }


  changeValue() {
    let newValue = this.setNewValue();
    this.timeoutID =  setTimeout(() => {
      if (newValue == this.currentValue) {
        if(this.secondsLeft>0)
          this.changeValue();
      }
     }, 700);
  }

  setNewValue() {
    let nextValue = this.randomIntFromInterval(1, 16);
    while (nextValue == this.currentValue)
      nextValue = this.randomIntFromInterval(1,16);

    this.currentValue = nextValue;
    this.setEmojis();
    return nextValue;
  }

   randomIntFromInterval(min, max) { 
   return Math.floor(Math.random() * (max - min + 1) + min);
  }


  setEmojis() {
    let elements = document.getElementsByClassName('game-btn');
    for (var i = 0; i < elements.length; i++) {
        elements[i].innerHTML = "🐱"
    }
    
    document.getElementById(this.currentValue.toString()).innerHTML = "👻";

  }

  volumeUp(silence:boolean) {
    this.silence = silence;
  }

  finishGame() {
    this.running = false;
    this.mainHub.addRanking({ points: this.points });
  }

}
