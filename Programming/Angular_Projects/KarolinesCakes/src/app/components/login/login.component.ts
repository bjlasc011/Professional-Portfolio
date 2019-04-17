import { Component, OnInit, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(
    private router: Router
  ) { }
  password: String;
  username: String;

  ngOnInit() {}
  onLogin = new EventEmitter();
  login() : void {
    if(this.username == 'admin' && this.password == 'admin'){
     this.router.navigate(["account"]);
     this.onLogin.emit({success: true})
    }
    else {
      alert("Invalid credentials");
      this.username = "";
      this.password = "";
    }
  }

}