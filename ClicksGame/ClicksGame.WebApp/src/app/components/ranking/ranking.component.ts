import { Component, OnInit } from '@angular/core';
import { RankingService } from '../../_services/ranking.service';

@Component({
  selector: 'ranking',
  templateUrl: './ranking.component.html',
  styleUrls: ['./ranking.component.css']
})
export class RankingComponent implements OnInit  {

  ranking: any[] = [];
  
  constructor(private rankingService: RankingService) {
  
  }



  ngOnInit(): void {
    this.rankingService.getRanking()
      .subscribe(
        (res:any) => {
          this.ranking = res;
        },
        console.error
      )
  }



}
