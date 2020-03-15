import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { error } from 'protractor';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}; // Empty object where we can store the username and password
  constructor(private authService: AuthService) { } // Inyect auth service into our contructor

  ngOnInit() {
  }

  login() {
    this.authService.Login(this.model)
    .subscribe(
      next => {
      console.log('Logged in successfully');
      },
      loginError => {
        console.log(loginError); // 'Failed to login'
      }
    );
    // console.log(this.model);
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token; // Returns true or false depending if it is empty
  }

  logOut() {
    localStorage.removeItem('token');
    console.log('logged out');
  }
}
