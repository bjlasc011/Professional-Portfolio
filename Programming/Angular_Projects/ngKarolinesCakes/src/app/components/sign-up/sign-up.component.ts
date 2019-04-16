import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  constructor(
    private router: Router
  ) { }

  ngOnInit() {
  }
  firstName: string = "";
  lastName: string = "";
  email: string = "";
  phone: string = "";
  newsletter: boolean = true;
  states: string[] = [
    'KY', 'IN', 'TN', 'OH'
  ];
  cardTypes: string[] = ["Visa", "Mastercard", "Discover", "AMEX"];
  years: string[] = ["2018", "2019", "2020", "2021", "2022", "2023", "2024", "2025", "2026"];
  months: string[] = ["JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP","OCT", "NOV", "DEC"];
  hide: boolean = true;
  pushAccount(){
    const link = ['/account'];
    this.router.navigate([link]);
  }
}
