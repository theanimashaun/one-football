import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { map } from 'rxjs/operators';
import { Country } from '../models/country';
import { LivescoreInfo } from '../models/livescoreinfo';
import { Highlight } from '../models/highlight';

@Injectable()
export class AppService {

  private baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  getCountries(): Observable<any> {
    return this.http
      .get<Country[]>(this.baseUrl + 'api/fetch/GetCountries')
      .pipe(map(response => response));
  }

  getCompetitions(): Observable<any> {
    return this.http
      .get<Country[]>(this.baseUrl + 'api/fetch/GetCompetitions')
      .pipe(map(response => response));
  }

  getStandings(leagueId: number): Observable<any> {
    return this.http
      .get<Country[]>(this.baseUrl + 'api/fetch/GetStandings/' + leagueId)
      .pipe(map(response => response));
  }

  getLivescores(): Observable<any> {
    return this.http
    .get<LivescoreInfo[]>(this.baseUrl + 'api/fetch/GetLiveScores')
    .pipe(map(response => response));
  }

  getHighLights(): Observable<any> {
    return this.http
    .get<Highlight[]>(this.baseUrl + 'api/fetch/GetVideoHighlights')
    .pipe(map(response => response));
  }
}
