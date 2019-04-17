import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(
    private dialog: MatDialog
  ) { }

  ngOnInit() {
  }
  openDialog: MatDialogRef<LoginComponent, any>;

  openNewDialog() {
    this.openDialog = this.dialog.open(LoginComponent);
    this.openDialog.componentInstance.onLogin.subscribe((data) =>{
      (data.success)? this.openDialog.close() : null;
    });
  }
}
