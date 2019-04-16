import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UploadEvent, UploadFile } from 'ngx-file-drop';
import { OrderService, Order } from '../services/order.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  
  constructor(
    private router: Router,
    private orderService: OrderService
  ) { }

  ngOnInit() {
    this.minDate = new Date();
    this.deliveryType = 'undecided';
    this.order = this.orderService.order;
  }

  ngOnDestroy(){
    this.orderService.order = this.order;
  }

  public files: UploadFile[] = [];
 
  public dropped(event: UploadEvent) {
    event.files.forEach((f) => {
    this.files.push(f);
    })
  }
  public deleteImg(uploadFile: UploadFile){
    this.files = this.files.filter((f)=>{
      return f.fileEntry.name !== uploadFile.fileEntry.name;
    })
  }
  order: Order;
  newsletter: boolean = true;
  glutenFree: boolean = false;
  picker: Date;
  deliveryType: string;
  showAddress:boolean = false;
  minDate: Date;
  treatRows: Itreat[] = [{name: "Cookie Cake", quantity: 1}];
  tierCount: number = 1;
  tiers: String[] = ['1', '2', '3', 'Request 4+'];
  states: string[] = [
    'KY', 'IN', 'TN', 'OH'
  ];
  servings: string[] = [
    '6" cake (serves 12)',
    '8" double layer (serves 20-25)',
    '10" and 6" dbouble stack (serves 40-45)',
    '1/4 sheet cake 9"x13" (serves 36)',
    '10" (serves 28-35)',
    '1/2 sheet cake 11"x15" (serves 54)',
    'Full sheet cake (serves 72)'
  ];
  flavorGroups: Object[] = [
    {
      name: 'Basic Cakes',
      flavors: [
        'French Vanilla', 'Chocolate', 'Marble', 'Strawberry'
      ]
    },
    {
      name: 'Premium Cakes',
      flavors: [
        'Almond', 'Amaretto','Carrot', 'Chocolate Chip', 'Coconut', 'Cookie Dough', 'Cookies & Cream',
        'Italian Cream', 'Banana', 'Lemon','Pancake', 'Pina Colada','Pineapple', 'Raspberry', 'Red Velvet',
        'Spice', 'White Chocolate', 'Hummingbird'
      ]
    },
    {
      name: 'Seasonal Cakes',
      flavors: [
        'Caramel Apple', 'Pumpkin', 'Pecan Pie', 'Sugar Cookie', 'Hot Chocolate', 'Gingerbread'
      ]
    },
    {
      name: 'Gluten Free',
      flavors: [
        'Vanilla', 'Chocolate', 'Carrot', 'Strawberry', 'Banana'
      ]
    }
  ]
  
  moreTreats: Object[] = [
    {
      name: 'Cupcakes',
      flavors: [
        'Basic', 'Premium', 'Mini Cupcakes Basic', 'Mini Cupcakes Premium', 'Jumbo Cupcake', 'Cupcake Cake / Smash Cake'
      ]
    },
    {
      name: 'More Treats',
      flavors: [
        'Cookie Cake', '9" Pie', 'Cake Pops', 'Cakes with Fresh Fruit'
      ]
    }
  ]

  frostings: String[] = [
    'Vanilla Buttercream', 'Decorator Icing', 'Chocolate Buttercream', 'Almond Buttercream','White Chocolate Buttercream', 'Cream Cheese Frosting',
    'Peanut Butter Frosting',  'Maple Buttercream', 'Caramel Icing', 'Brown Sugar Buttercream','Marshmallow Buttercream', 'Lemon Cream Cheese Frosting',
    'Raspberry Buttercream', 'Coconut Cream Cheese Frosting', 'Strawberry Cream Cheese Frosting', 'Cookies & Cream', 'Chocolate Ganache'
  ]

  fillings: String[] = [
    'None','Salted Caramel', 'Fruit Preserves', 'Lemon Curd','Chocolate Ganache', 'Marshmallow',  'Peanut Butter Buttercream', 
    'Lemon Cream Cheese Frosting','Coconut Cream Cheese Frosting','Strawbetty Cream Cheese Frosting', 'Nutella'
  ]

  quantity: number[] = [
    1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18
  ]
  public deliveryChange(): void{
    if(this.deliveryType=='delivery'){
      this.showAddress = true;
    }
    else {
      this.showAddress = false;
    }
  }
  navCakeGallery(): void{
    console.log('nav to cake-gallery');
    const link = ['/cake-gallery']
    this.router.navigate([link]);
  }
  addTreatRow(): void{
    if(this.treatRows != undefined)
      this.treatRows.push({name: "Cookie Cake", quantity: 1});
    else this.treatRows = [{name: "Cookie Cake", quantity: 1}];
  }
  popTreatRow(){
    this.treatRows.pop();
  }
  removeTreat(ind: number){
    this.treatRows.splice(ind, 1);
  }
  pushAccount(){
    this.router.navigate(['account']);
  }
}

export interface Itreat{
  name: string;
  quantity: number;
}
