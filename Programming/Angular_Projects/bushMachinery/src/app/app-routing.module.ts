import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { MachineryComponent } from './machinery/machinery.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { EmailerComponent } from './emailer/emailer.component';


export const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'machinery', component: MachineryComponent },
  { path: 'about', component: AboutComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'emailer', component: EmailerComponent },
  { path: '**', component: HomeComponent }
];


@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload', useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
