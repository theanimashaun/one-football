import { Component, OnInit, ViewChild } from '@angular/core';
import { Highlight } from '../models/highlight';
import { AppService } from '../services/app.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-video',
  templateUrl: './video.component.html',
  styleUrls: ['./video.component.css']
})
export class VideoComponent implements OnInit {

  loading: boolean;
  highlights: Highlight[];
  currentHighlight: Highlight;
  @ViewChild('modal') modal;

  constructor(private appService: AppService, private sanitizer: DomSanitizer) {
    this.highlights = [];
    this.loading = true;
    this.currentHighlight = <Highlight>{};
  }

  playVideo(title: string, url: string) {
    this.currentHighlight = <Highlight>{
      title: title,
      url: this.sanitizer.bypassSecurityTrustHtml(url)
    };
    this.modal.show();
  }

  ngOnInit() {
    this.appService.getHighLights().subscribe(highlights => {
      this.highlights = highlights;
      this.loading = false;
    });
  }

}
