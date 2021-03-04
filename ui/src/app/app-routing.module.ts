import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardsComponent } from './cards/cards.component';
import { FirstpageComponent } from './firstpage/firstpage.component';
import { HomeComponent } from './home/home.component';
import { SearchPatientsComponent } from './search-patients/search-patients.component';

const routes: Routes = [
  {
    path:'', redirectTo:'/home', pathMatch:'full'
  },
  {
    path:'home',
    component:FirstpageComponent
  },
  {
    path:'login',
    component:CardsComponent
  },
  {
    path:'welcome',
    component: HomeComponent
  },
  {
    path: 'welcome/search-patients',
    component: SearchPatientsComponent

  }


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
