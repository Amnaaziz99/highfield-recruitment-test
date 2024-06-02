import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { provideHttpClient, withInterceptorsFromDi } from '@angular/common/http'; 

import { AppComponent } from './app.component';
import { UserDataComponent } from './components/user-data/user-data.component';

@NgModule({
  declarations: [
    AppComponent,
    UserDataComponent
  ],
  imports: [
    BrowserModule,
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi()) 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }