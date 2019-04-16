import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss']
})
export class AboutComponent implements OnInit {
  description: string = `Bush Machinery is specialty machinery broker that handle any of your machine needs.
  Established in 1985, Bush Machinery has been always found the best deals for their customers and offers a 
  satisfaciton guarentee or your money back. All machinery is available to view upon request, just send us an email or call to
  set up an appointment.`;
  imgUrl: string = '../../assets/mark.jpg'
  constructor() { }

  ngOnInit() {
  }

}
