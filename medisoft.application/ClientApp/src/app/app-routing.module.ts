import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VisitsPageComponent } from './visits/visits-page/visits-page.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { ContainerComponent } from './container/container.component';
import { ContainerHomeComponent } from './container-home/container-home.component';
import { VisitDetailsComponent } from './visits/visit-details/visit-details.component';
import { VisitsMainComponent } from './visits/visits-main/visits-main.component';

const routes: Routes = [
  { path: '', component:HomeComponent },
  { path: 'home', component:ContainerComponent,children:[
    { path: 'visits', component: VisitsMainComponent,children:[
      { path: '', component: VisitsPageComponent},
      {path: 'details/:id', component: VisitDetailsComponent}
    ] },
    { path: 'header', component: HeaderComponent },
    { path: '', component: ContainerHomeComponent },


  ] }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
