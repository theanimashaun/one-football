import { Component, OnInit } from '@angular/core';
import { AppService } from '../services/app.service';
import { LivescoreInfo } from '../models/livescoreinfo';

@Component({
  selector: 'app-live-scores',
  templateUrl: './live-scores.component.html',
  styleUrls: ['./live-scores.component.css']
})
export class LiveScoresComponent implements OnInit {

  livescores: LivescoreInfo[];
  loading: boolean;

  constructor(private appService: AppService) {
    this.livescores = [];
    this.loading = true;
  }

  ngOnInit() {
    this.appService.getLivescores().subscribe(livescores => {
      this.livescores = livescores;
      this.loading = false;
    });
  }

}
