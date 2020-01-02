import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { BookListComponent } from './book-list/book-list.component';
import { RootComponent } from './root/root.component';


const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'books', component: BookListComponent },
  { path: 'root', component: RootComponent },
  { path: '',   redirectTo: '/root', pathMatch: 'full' },
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
