import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { SidebarModule } from './sidebar/sidebar.module';
import { FooterModule } from './shared/footer/footer.module';
import { NavbarModule } from './shared/navbar/navbar.module';
import { LiveScoresComponent } from './live-scores/live-scores.component';
import { AppService } from './services/app.service';
import { VideoComponent } from './video/video.component';
import { VideoModalComponent } from './video/video-modal/video-modal.component';
import { StandingsComponent } from './standings/standings.component';

@NgModule({
  declarations: [
    AppComponent,
    LiveScoresComponent,
    VideoComponent,
    VideoModalComponent,
    StandingsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: LiveScoresComponent, pathMatch: 'full' },
      { path: 'livescores', component: LiveScoresComponent },
      { path: 'videos', component: VideoComponent },
      { path: 'standings', component: StandingsComponent }
    ]),
    SidebarModule,
    FooterModule,
    NavbarModule
  ],
  providers: [
    AppService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
