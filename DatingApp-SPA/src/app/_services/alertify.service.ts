import { Injectable } from '@angular/core';
import * as alertify from 'alertifyjs';
// Check if there is a type definition file: >  npm install @types/alertifyjs
// If it fails declare a module 'alertifyjs' -> Declaration that this package exist

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

constructor() {}

  confirm(message: string, okCallback: () => any){
    alertify.confirm(message, (e: any) =>
    {
      if (e) {
        okCallback();
      } else {}
    }
    );
  }

  success(message: string) {
    alertify.success(message);
  }

  error(message: string) {
    alertify.error(message);
  }

  warning(message: string) {
    alertify.warning(message);
  }

  message(message: string) {
    alertify.message(message);
  }
}
