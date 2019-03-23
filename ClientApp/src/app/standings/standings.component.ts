import { Component, OnInit } from '@angular/core';
import { AppService } from '../services/app.service';
import { Competition } from '../models/competition';
import { StandingInfo } from '../models/standinginfo';

@Component({
  selector: 'app-standings',
  templateUrl: './standings.component.html',
  styleUrls: ['./standings.component.css']
})
export class StandingsComponent implements OnInit {
  loadingCountries: boolean;
  loadingStandings: boolean;
  competitions: Competition[];
  standings: StandingInfo[];

  constructor(private appService: AppService) {
    this.loadingCountries = true;
    this.loadingStandings = false;
    this.competitions = [];
    this.standings = [];
  }

  fetchStandings(leagueId: number) {
    this.loadingStandings = true;
    this.appService.getStandings(leagueId).subscribe(standings => {
      this.standings = standings;
      this.loadingStandings = false;
    });
  }

  ngOnInit() {
    this.appService.getCompetitions().subscribe(competitions => {
      this.competitions = competitions;
      this.loadingCountries = false;
    });
  }

}
