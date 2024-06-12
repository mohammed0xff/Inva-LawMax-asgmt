import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { LawyerComponent } from './pages/lawyer/lawyer.component';
import { CaseComponent } from './pages/case/case.component';
import { HearingComponent } from './pages/hearing/hearing.component';

const appRoutes: Routes = [
  { path: '', redirectTo: 'lawyers', pathMatch: 'full' }, 
  { path: 'cases', component: CaseComponent },
  { path: 'lawyers', component: LawyerComponent },
  { path: 'hearings', component: HearingComponent },
  { path: '**', redirectTo: '/lawyers' } // Fallback route
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
