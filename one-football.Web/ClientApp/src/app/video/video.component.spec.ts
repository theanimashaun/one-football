import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VideoComponent } from './video.component';
import { Highlight } from '../models/highlight';
import { of } from 'rxjs';
import { AppService } from '../services/app.service';
import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  // tslint:disable-next-line
  selector: 'app-video-modal',
  template: ''
})
class VideoModalStubComponent {
}

describe('VideoComponent', () => {
  let component: VideoComponent;
  let fixture: ComponentFixture<VideoComponent>;
  let appServiceSpy: {
    getHighLights: jasmine.Spy;
  };

  beforeEach(async(() => {
    appServiceSpy = jasmine.createSpyObj('AppService', ['getHighLights']);
    appServiceSpy.getHighLights.and.returnValue(of([<Highlight>{}]));

    TestBed.configureTestingModule({
      declarations: [
        VideoComponent,
        VideoModalStubComponent
      ],
      providers: [
        { provide: AppService, useValue: appServiceSpy }
      ]
    })
      .compileComponents();

    fixture = TestBed.createComponent(VideoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VideoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
    expect(component.highlights.length).toEqual(1);
    expect(component.loading).toBeFalsy();
  });
});
