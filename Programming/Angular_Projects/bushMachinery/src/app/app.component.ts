import { Component, OnInit } from '@angular/core';
import { MachineryService, ICategory } from 'src/services/machinery.service';
import { Router, ActivatedRoute } from '@angular/router';
import { appear } from './app.animations';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations: [appear]
})
export class AppComponent implements OnInit {
  categories: ICategory[] = [];
  showInventory: boolean = false;

  constructor(
    private machineService: MachineryService,
    private router: Router,
    private route: ActivatedRoute,
  ) { }


  ngOnInit() {
    this.initInventory();
    this.router.navigateByUrl('/home');
    window.scrollTo(0,0);
  }

  initInventory() {
    this.categories = this.machineService.categories;
    console.log(this.categories);
  }

  mouseEnter() {
    this.showInventory = true;
  }
  mouseLeave() {
    this.showInventory = false;
  }

  navTo(name: string) {
    this.showInventory = false;
    this.router.navigateByUrl('/home').then(() =>
      this.router.navigate(['/machinery', { id: name }])
    );
  }
}
