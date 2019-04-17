import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-newsletter-confirm',
  templateUrl: './newsletter-confirm.component.html',
  styleUrls: ['./newsletter-confirm.component.css']
})
export class NewsletterConfirmComponent implements OnInit {
  constructor(
    private dialog: MatDialogRef<NewsletterConfirmComponent, any>
  ) { }

  ngOnInit() {
  }
  dismiss(){
    this.dialog.close();
  }
}
