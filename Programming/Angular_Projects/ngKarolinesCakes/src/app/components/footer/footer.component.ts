import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material';
import { NewsletterConfirmComponent } from '../newsletter-confirm/newsletter-confirm.component';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {

  constructor(
    private dialog: MatDialog
  ) { }

  ngOnInit() {
  }

  openDialog: MatDialogRef<NewsletterConfirmComponent, any>;

  openNewDialog() {
    this.openDialog = this.dialog.open(
      NewsletterConfirmComponent, {
        width: '300px',
        height: '225px'
      });
  }

  signUpNewsletter(){
    this.openNewDialog();
  }
}
