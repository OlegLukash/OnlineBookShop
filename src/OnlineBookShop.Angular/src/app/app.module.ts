import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BookListComponent } from './book-list/book-list.component';
import { RootComponent } from './root/root.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import '../styles/styles.scss';

import {
   MatButtonModule,
   MatButtonToggleModule,
   MatCardModule,
   MatIconModule,
   MatMenuModule,
   MatListModule,
   MatSidenavModule,
   MatToolbarModule
 } from '@angular/material';


const appRoutes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'books', component: BookListComponent },
  { path: 'root', component: RootComponent }
];

@NgModule({
   declarations: [
      AppComponent,
      BookListComponent,
      HomeComponent,
      BookListComponent,
      RootComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,

      MatButtonModule,
      MatButtonToggleModule,
      MatCardModule,
      MatIconModule,
      MatMenuModule,
      MatListModule,
      MatSidenavModule,
      MatToolbarModule,

      HttpClientModule,
      RouterModule.forRoot(
         appRoutes
       )
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
