import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
//import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BookListComponent } from './book-list/book-list.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import '../styles/styles.scss';

// import {
//    MatAutocompleteModule,
//   MatButtonModule,
//   MatButtonToggleModule,
//   MatCardModule,
//   MatCheckboxModule,
//   MatChipsModule,
//   MatStepperModule,
//   MatDatepickerModule,
//   MatDialogModule,
//   MatExpansionModule,
//   MatGridListModule,
//   MatIconModule,
//   MatInputModule,
//   MatListModule,
//   MatMenuModule,
//   MatNativeDateModule,
//   MatPaginatorModule,
//   MatProgressBarModule,
//   MatProgressSpinnerModule,
//   MatRadioModule,
//   MatRippleModule,
//   MatSelectModule,
//   MatSidenavModule,
//   MatSliderModule,
//   MatSlideToggleModule,
//   MatSnackBarModule,
//   MatSortModule,
//   MatTableModule,
//   MatTabsModule,
//   MatToolbarModule,
//   MatTooltipModule,
//  } from '@angular/material';
import { AppRoutingModule } from './app-routing.module';


@NgModule({
   declarations: [
      AppComponent,
     // BookListComponent,
     // HomeComponent,
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,

      // MatAutocompleteModule,
      // MatButtonModule,
      // MatButtonToggleModule,
      // MatCardModule,
      // MatCheckboxModule,
      // MatChipsModule,
      // MatStepperModule,
      // MatDatepickerModule,
      // MatDialogModule,
      // MatExpansionModule,
      // MatGridListModule,
      // MatIconModule,
      // MatInputModule,
      // MatListModule,
      // MatMenuModule,
      // MatNativeDateModule,
      // MatPaginatorModule,
      // MatProgressBarModule,
      // MatProgressSpinnerModule,
      // MatRadioModule,
      // MatRippleModule,
      // MatSelectModule,
      // MatSidenavModule,
      // MatSliderModule,
      // MatSlideToggleModule,
      // MatSnackBarModule,
      // MatSortModule,
      // MatTableModule,
      // MatTabsModule,
      // MatToolbarModule,
      // MatTooltipModule,

      //HttpClientModule,
      AppRoutingModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
