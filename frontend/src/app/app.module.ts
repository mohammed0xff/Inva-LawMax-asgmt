import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { Router, RouterLink, RouterModule, RouterOutlet } from '@angular/router';

import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { LawyerComponent } from './pages/lawyer/lawyer.component';
import { CaseComponent } from './pages/case/case.component';
import { HearingComponent } from './pages/hearing/hearing.component';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    LawyerComponent,
    CaseComponent,
    HearingComponent
  ],
  imports: [
    BrowserAnimationsModule,
    AppRoutingModule,
    BrowserModule,
    CommonModule,
    RouterOutlet,
    FormsModule,
    RouterLink,
  ],
  providers:[
    provideHttpClient(withInterceptorsFromDi())
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule {
  constructor(router: Router) {
    // Use a custom replacer to display function names in the route configs
    const replacer = (key, value) => (typeof value === 'function') ? value.name : value;
    console.log('Routes: ', JSON.stringify(router.config, replacer, 2));
  }
}
