import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { BookListComponent } from './book-list/book-list.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'books', component: BookListComponent }
];

@NgModule({
   declarations: [
      AppComponent,
      BookListComponent,
      HomeComponent,
      BookListComponent
   ],
   imports: [
      BrowserModule,
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
