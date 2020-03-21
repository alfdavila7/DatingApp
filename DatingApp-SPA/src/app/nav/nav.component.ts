import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}; // Empty object where we can store the username and password


  constructor(public authService: AuthService, private alerfity: AlertifyService, private router: Router) { }
  // Inyect auth service into our contructor

  ngOnInit() {
  }

  login() {
    this.authService.Login(this.model)
    .subscribe(
      next => {
        this.alerfity.success('Logged in successfully');
      },
      error => {
        this.alerfity.error(error); // 'Failed to login'
      },
      () => {
        this.router.navigate(['/members']); // complete
      }
    );
    // console.log(this.model);
  }

  loggedIn() {
    return this.authService.loggedIn();
    // const token = localStorage.getItem('token');
    // return !!token; // Returns true or false depending if it is empty
  }

  logOut() {
    localStorage.removeItem('token');
    this.alerfity.message('logged out');
    this.router.navigate(['/home']);
  }
}
