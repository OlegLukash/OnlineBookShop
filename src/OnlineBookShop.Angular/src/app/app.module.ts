import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { MatInputModule } from '@angular/material';
import { ReactiveFormsModule } from '@angular/forms';
import { JwtModule } from '@auth0/angular-jwt';

import { AppComponent } from './app.component';
import { NotfoundpageComponent } from './shared/notfoundpage/notfoundpage.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './_guards/auth.guard';
import { environment } from 'src/environments/environment';

@NgModule({
   declarations: [
      AppComponent,
      NotfoundpageComponent,
      LoginComponent
   ],
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      HttpClientModule,
      AppRoutingModule,
      ReactiveFormsModule,
      JwtModule.forRoot({
         config: {
           tokenGetter: () => localStorage.getItem('accessToken'),
           whitelistedDomains: [environment.whitelistedDomainsForSendingToken],
           blacklistedRoutes: [environment.blacklistedRoutes]
      }}),//TODO: Change to HttpInterceptor approach

      MatInputModule
   ],
   providers: [AuthGuard],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
