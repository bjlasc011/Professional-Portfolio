import { Component, OnInit } from '@angular/core';
import { MachineryService, ICategory } from 'src/services/machinery.service';
import { Router, ActivatedRoute, ParamMap } from '@angular/router';
import { MatDialog } from '@angular/material';
import { SubmitModalComponent } from '../submit-modal/submit-modal.component';
import { img } from '../app.animations';

@Component({
  selector: 'app-machinery',
  templateUrl: './machinery.component.html',
  styleUrls: ['./machinery.component.scss'],
  animations: [img]
})
export class MachineryComponent implements OnInit {
  catID: string;
  category: ICategory;
  currImgs: number[] = [];
  icons: number[] = [0, 1, 2, 3, 4, 5, 6]
  name: any;
  constructor(
    private machineService: MachineryService,
    private router: Router,
    private route: ActivatedRoute,
    public dialog: MatDialog
  ) {
    this.catID = this.route.snapshot.paramMap.get('id');
    this.category = this.machineService.getItem(this.catID);
    this.category.items.forEach(i => this.currImgs.push(0));
  }

  ngOnInit() {
    console.log(this.category);
  }

  prev(j: number) {
    if (this.currImgs[j] > 0) {
      this.currImgs[j] -= 1;
    } else {
      this.currImgs[j] = this.category.items[j].imgUrls.length - 1;
    }
    console.log(this.currImgs[j]);
  }
  next(j: number) {
    if (this.currImgs[j] < this.category.items[j].imgUrls.length - 1) {
      this.currImgs[j] += 1;
    } else {
      this.currImgs[j] = 0;
    }
    console.log(this.currImgs[j]);
  }

  getUrl(j: number, i: number): string {
    let ind: number = this.currImgs[j] + (-3 + i);
    if (ind < 0) {
      ind = (this.category.items[j].imgUrls.length - 4) - ind;
    }
    else if (ind > this.category.items[j].imgUrls.length - 1) {
      ind = (this.category.items[j].imgUrls.length - ind)
    }
    console.log(`ind: ${ind} - length: ${this.category.items[j].imgUrls.length}`);
    console.log(this.category.items[j].imgUrls[ind]);
    return this.category.items[j].imgUrls[ind];
  }

  setImg(j: number, i: number) {
    let ind: number = this.currImgs[j] + (-3 + i);
    if (ind < 0) {
      ind = (this.category.items[j].imgUrls.length - 4) - ind;
    }
    this.currImgs[j] = ind;
    console.log(this.currImgs);
  }

  displaySubmitModal() {
    const dialogRef = this.dialog.open(SubmitModalComponent, {
      width: '250px',
      data: {name: this.name}
    });

    dialogRef.afterClosed().subscribe(result => { });
  }
}
