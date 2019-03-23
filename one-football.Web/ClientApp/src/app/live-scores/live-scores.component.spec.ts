import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { LiveScoresComponent } from './live-scores.component';
import { AppService } from '../services/app.service';
import { LivescoreInfo } from '../models/livescoreinfo';
import { of } from 'rxjs';

describe('LiveScoresComponent', () => {
  let component: LiveScoresComponent;
  let fixture: ComponentFixture<LiveScoresComponent>;
  let appServiceSpy: {
    getLivescores: jasmine.Spy;
  };

  beforeEach(async(() => {
    appServiceSpy = jasmine.createSpyObj('AppService', ['getLivescores']);

    appServiceSpy.getLivescores.and.returnValue(of([<LivescoreInfo>{}]));

    TestBed.configureTestingModule({
      declarations: [
        LiveScoresComponent
      ],
      providers: [
        { provide: AppService, useValue: appServiceSpy }
      ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(LiveScoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create and get livescores', () => {
    expect(component).toBeDefined();
    expect(appServiceSpy.getLivescores.calls.any()).toBeTruthy();
    expect(component.livescores.length).toBe(1);
  });
});
