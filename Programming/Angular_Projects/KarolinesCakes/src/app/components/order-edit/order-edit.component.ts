import { Component, OnInit, EventEmitter, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-order-edit',
  templateUrl: './order-edit.component.html',
  styleUrls: ['./order-edit.component.css']
})
export class OrderEditComponent implements OnInit {
  onSubmit = new EventEmitter;
  onCancel = new EventEmitter;
  minDate: Date;
  showAddress: boolean = false;
  deliveryType: string;
  deliveryDate: Date | string;

  constructor(
    public dialogRef: MatDialogRef<OrderEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IEditOrder,
  )
  {
    this.minDate = new Date;
    this.deliveryDate = this.data.deliveryDate;
    this.deliveryType = this.data.deliveryType;
    console.log(this.deliveryDate);
    console.log(this.deliveryType);
  }

  ngOnInit(){}

  submit() {
    this.data.deliveryType = this.deliveryType;
    this.data.deliveryDate = this.deliveryDate;
    console.log(this.data);
    this.onSubmit.emit({data: this.data})
    this.dialogRef.close();
  }

  cancel(){
    this.onCancel.emit({cancel: true})
  }

  public deliveryChange(): void{
    if(this.data.deliveryType=='delivery'){
      this.showAddress = true;
    }
    else {
      this.showAddress = false;
    }
  }

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
}

export interface IEditOrder {
  cancel: boolean,
  address1: string,
  address2: string,
  city: string,
  state: string,
  zip: string,
  deliveryDate: any, //requested on
  deliveryType: string;
}