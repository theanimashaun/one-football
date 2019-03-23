import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StandingsComponent } from './standings.component';
import { Competition } from '../models/competition';
import { of } from 'rxjs';
import { StandingInfo } from '../models/standinginfo';
import { AppService } from '../services/app.service';

describe('StandingsComponent', () => {
  let component: StandingsComponent;
  let fixture: ComponentFixture<StandingsComponent>;
  let appServiceSpy: {
    getStandings: jasmine.Spy;
    getCompetitions: jasmine.Spy;
  };

  beforeEach(async(() => {
    appServiceSpy = jasmine.createSpyObj('AppService', ['getCompetitions', 'getStandings']);
    appServiceSpy.getCompetitions.and.returnValue(of([<Competition>{}]));
    appServiceSpy.getStandings.and.returnValue(of([<StandingInfo>{}]));

    TestBed.configureTestingModule({
      declarations: [StandingsComponent],
      providers: [
        { provide: AppService, useValue: appServiceSpy }
      ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(StandingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StandingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
    expect(appServiceSpy.getCompetitions).toHaveBeenCalled();
    expect(component.competitions.length).toEqual(1);
  });

  it('should fetch standings', () => {
    component.fetchStandings(0);
    expect(appServiceSpy.getStandings).toHaveBeenCalledWith(0);
    expect(component.standings.length).toEqual(1);
  });
});
