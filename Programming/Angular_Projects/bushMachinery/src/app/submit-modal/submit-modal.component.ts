import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-submit-modal',
  templateUrl: './submit-modal.component.html',
  styleUrls: ['./submit-modal.component.css']
})
export class SubmitModalComponent implements OnInit {
  name: string;
  constructor(
    public dialogRef: MatDialogRef<SubmitModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) { 
    this.name = data.name;
  }

  ngOnInit() {
  }

}
