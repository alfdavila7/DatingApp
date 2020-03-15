import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
// Components are inyectable by default, but services are not. Thats why you need to specify them
@Injectable({ // Declarator
  providedIn: 'root' // Which component is providing the service. Which in this case is the app.module
})
export class AuthService {
  baseURL = 'http://localhost:5000/api/auth/';

  constructor(private http: HttpClient) { } // Use Http client module

  Login(model: any) // Model objects from nav bar
  {
    // We dont need a header because by default it will expect the content as application Json
    return this.http.post(this.baseURL + 'login', model) // Return an observable back
    .pipe( // Chain or response and transform it and do something with that
      map(
        (response: any) => {
          const user = response; // Token object
          if (user) { // Something inside?
            localStorage.setItem('token', user.token);
          }
        }
      )
    );
  }

  register(model: any){
    return this.http.post(this.baseURL + 'register', model);
  }
}
