import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotfoundpageComponent } from './shared/notfoundpage/notfoundpage.component';

const appRoutes: Routes = [
  { path: 'admin', loadChildren: () => import('./admin/admin.module').then(mod => mod.AdminModule)},
  { path: '',   redirectTo: '/admin', pathMatch: 'full' },
  { path: '**', component: NotfoundpageComponent }
];


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
