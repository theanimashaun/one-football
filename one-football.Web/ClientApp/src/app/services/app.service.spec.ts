import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { AppService } from './app.service';
import { HttpClient } from '@angular/common/http';
import { of } from 'rxjs';
import { Country } from '../models/country';
import { Competition } from '../models/competition';
import { Highlight } from '../models/highlight';
import { LivescoreInfo } from '../models/livescoreinfo';
import { StandingInfo } from '../models/standinginfo';

describe('AppService', () => {
  let httpTestingController: HttpTestingController;
  let httpClientSpy: {
    get: jasmine.Spy;
  };

  let service: AppService;

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);

    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [AppService,
        { provide: HttpClient, useValue: httpClientSpy },
        { provide: 'BASE_URL', useValue: '' }
      ]
    }).compileComponents();

    httpTestingController = TestBed.get(HttpTestingController);
    service = TestBed.get(AppService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get countries', () => {
    httpClientSpy.get.and.returnValue(of([<Country>{}]));
    service.getCountries().subscribe(res => {
      expect(httpClientSpy.get).toHaveBeenCalled();
      expect(res).toEqual([<Country>{}]);
    });
  });

  it('should get competitions', () => {
    httpClientSpy.get.and.returnValue(of([<Competition>{}]));
    service.getCompetitions().subscribe(res => {
      expect(httpClientSpy.get).toHaveBeenCalled();
      expect(res).toEqual([<Competition>{}]);
    });
  });

  it('should get highlights', () => {
    httpClientSpy.get.and.returnValue(of([<Highlight>{}]));
    service.getHighLights().subscribe(res => {
      expect(httpClientSpy.get).toHaveBeenCalled();
      expect(res).toEqual([<Highlight>{}]);
    });
  });

  it('should get livescores', () => {
    httpClientSpy.get.and.returnValue(of([<LivescoreInfo>{}]));
    service.getLivescores().subscribe(res => {
      expect(httpClientSpy.get).toHaveBeenCalled();
      expect(res).toEqual([<LivescoreInfo>{}]);
    });
  });

  it('should get standings', () => {
    httpClientSpy.get.and.returnValue(of([<StandingInfo>{}]));
    service.getStandings(0).subscribe(res => {
      expect(httpClientSpy.get).toHaveBeenCalled();
      expect(res).toEqual([<StandingInfo>{}]);
    });
  });
});
