import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http'; // To query from the Database
import { FormsModule } from '@angular/Forms'; // To use the bidirectional component

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './_services/auth.service';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ErrorInterceptorProvider } from './_services/error.interceptor';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule // ImportAngularformsforthehtmlcomponent
   ],
   providers: [
      ErrorInterceptorProvider // Inyect the error handling
      // Addtheservicestoourmainapp\\nAuthService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
