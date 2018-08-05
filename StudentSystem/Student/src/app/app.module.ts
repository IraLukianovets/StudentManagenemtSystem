import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MatInputModule, 
  MatButtonModule, 
  MatCardModule,
  MatListModule, 
  MatToolbarModule,
} 
  from '@angular/material';
import { FormsModule} from '@angular/forms';
import { RouterModule} from '@angular/router';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';

const routes = [
  {path:'login', component: LoginComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,

     ],
  imports: [
    BrowserModule, 
    NgModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    BrowserAnimationsModule,
    MatInputModule, 
    MatButtonModule, 
    MatCardModule,
    MatListModule,
    FormsModule,
    MatToolbarModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
