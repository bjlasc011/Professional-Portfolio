import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';

import { MatButtonModule, MatCheckboxModule, MatNativeDateModule, MatTableModule, MatMenuModule, MatProgressSpinnerModule } from '@angular/material';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';

import { MatListModule } from '@angular/material/list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatToolbarModule } from '@angular/material/toolbar';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatRadioModule } from '@angular/material/radio';
import { MatGridListModule } from '@angular/material/grid-list';
import { FileDropModule } from 'ngx-file-drop';

import { AppComponent } from './app.component';
import { OrdersComponent } from './components/orders/orders.component';
import { CakeGalleryComponent } from './components/cake-gallery/cake-gallery.component';
import { AppRoutingModule } from './routes/routes.module';
import { FooterComponent } from './components/footer/footer.component';
import { ImgDialogComponent } from './components/img-dialog/img-dialog.component';
import { LoginComponent } from './components/login/login.component';
import { NavComponent } from './components/nav/nav.component';
import { SignUpComponent } from './components/sign-up/sign-up.component';
import { AccountComponent } from './components/account/account.component';
import { ProductsComponent } from './components/products/products.component';
import { ContactComponent } from './components/contact/contact.component';
import { OrderEditComponent } from './components/order-edit/order-edit.component';
import { OrderService } from './components/services/order.service';
import { NewsletterConfirmComponent } from './components/newsletter-confirm/newsletter-confirm.component';

@NgModule({
  declarations: [
    AppComponent,
    OrdersComponent,
    CakeGalleryComponent,
    FooterComponent,
    ImgDialogComponent,
    LoginComponent,
    NavComponent,
    SignUpComponent,
    AccountComponent,
    ProductsComponent,
    ContactComponent,
    OrderEditComponent,
    NewsletterConfirmComponent
  ],
  imports: [
    // BrowserModule, 
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    FileDropModule,
    FormsModule,
    MatButtonModule,
    MatCardModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatDialogModule,
    MatFormFieldModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatNativeDateModule,
    MatSelectModule,
    MatSidenavModule,
    MatSlideToggleModule,
    MatToolbarModule,
    MatRadioModule,
    ReactiveFormsModule,
    AppRoutingModule,
    MatTableModule,
    MatMenuModule,
    MatProgressSpinnerModule
  ],
  providers: [
    MatNativeDateModule,
    OrderService
  ],
  bootstrap: [AppComponent],
  entryComponents: [
    ImgDialogComponent,
    LoginComponent,
    OrderEditComponent,
    NewsletterConfirmComponent
  ]
})
export class AppModule { }
