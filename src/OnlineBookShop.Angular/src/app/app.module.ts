import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { NotfoundpageComponent } from './shared/notfoundpage/notfoundpage.component';

@NgModule({
   declarations: [
      AppComponent,
      NotfoundpageComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,

      HttpClientModule,
      AppRoutingModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
