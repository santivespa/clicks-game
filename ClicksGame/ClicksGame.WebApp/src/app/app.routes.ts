import { Routes } from '@angular/router';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';
import { HomeComponent } from './components/home/home.component';
import { MainCounterComponent } from './components/main-counter/main-counter.component';
import { GameComponent } from './components/game/game.component';
import { RankingComponent } from './components/ranking/ranking.component';


export const ROUTES: Routes = [

  {
    path: '', component: MainLayoutComponent,
    children: [
      { path: '', pathMatch: "full", component: GameComponent } ,
      { path: 'game', component: GameComponent },
      { path: 'ranking', component: RankingComponent },

    ]
  }

];
