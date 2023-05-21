import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { VisitsPageComponent } from './visits/visits-page/visits-page.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { ContainerComponent } from './container/container.component';
import { ContainerHomeComponent } from './container-home/container-home.component';
import { VisitDetailsComponent } from './visits/visit-details/visit-details.component';
import { VisitsMainComponent } from './visits/visits-main/visits-main.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatDialogModule} from '@angular/material/dialog';
import { TranscriptDialogComponent } from './dialogd/transcript-dialog/transcript-dialog.component';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import {MatCardModule} from '@angular/material/card';

@NgModule({
  declarations: [
    AppComponent,
    VisitsPageComponent,
    HomeComponent,
    HeaderComponent,
    ContainerComponent,
    ContainerHomeComponent,
    VisitDetailsComponent,
    VisitsMainComponent,
    TranscriptDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    BrowserAnimationsModule,
    MatDialogModule,
    HttpClientModule,
    MatCardModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
