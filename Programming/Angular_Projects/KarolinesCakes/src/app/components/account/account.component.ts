import { Component, OnInit, EventEmitter } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { OrderEditComponent, IEditOrder } from '../order-edit/order-edit.component';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  cancel: boolean = false;
  editFormSub: Subscription;
  addressEdit: boolean = false;
  phoneEdit: boolean = false;
  emailEdit: boolean = false;

  firstName = "Ben";
  lastName = "Lascurain";
  phone = "(502) 662-5800";
  email = "benjay@gmail.com";
  address1 = "543 Cakeland Dr";
  address2 = "Apt 202";
  city = "Louisville";
  state = "KY";
  zip = "40243";
  orderDate: Date | string = new Date().toLocaleDateString();
  deliveryType: string = 'delivery';
  deliveryDate: Date | string = new Date().toLocaleDateString();
  fullfilledDate: Date | string = 'pending';
  orderNum: string = '12005';
  price: string = `$80.56`
  description: string = "Some cake discription goes here.";
  payment: string = 'pending';
  tierCount: string = '2';
  servings: string = '10" and 6" dbouble stack (serves 40-45)';
  flavorCake: string = 'Italian Cream';
  flavorFrosting: string = 'Raspberry Buttercream';
  fillings: string = 'None';

  constructor( private dialog: MatDialog) { }

  ngOnInit(){}
  
  ngOnDestroy() {}

  orders = [
    {
      address1: this.address1,
      address2: this.address2,
      city: this.city,
      state: this.state,
      zip: this.zip,
      orderDate: this.orderDate, //submitted on
      deliveryDate: this.deliveryDate, //requested on
      deliveryType: this.deliveryType,
      fullfilledDate: this.fullfilledDate,
      orderNum: '23456',
      price: this.price,
      description: this.description,
      payment: this.payment,
      tierCount: this.tierCount,
      servings: this.servings,
      flavorCake: this.flavorCake,
      flavorFrosting: this.flavorFrosting,
      fillings: this.fillings
    },
    {
      address1: this.address1,
      address2: this.address2,
      city: this.city,
      state: this.state,
      zip: this.zip,
      orderDate: this.orderDate, //submitted on
      deliveryDate: this.deliveryDate, //requested on
      deliveryType: this.deliveryType,
      fullfilledDate: new Date().toLocaleDateString(),
      orderNum: '02616',
      price: '$120.22',
      description: 'Birthday cake for',
      payment: 'paid',
      tierCount: this.tierCount,
      servings: '10" and 6" dbouble stack (serves 40-45)',
      flavorCake: this.flavorCake,
      flavorFrosting: this.flavorFrosting,
      fillings: this.fillings
    },
    {
      address1: this.address1,
      address2: this.address2,
      city: this.city,
      state: this.state,
      zip: this.zip,
      orderDate: new Date().toLocaleDateString(), //submitted on
      deliveryDate: new Date('December 17, 2018 03:24:00').toLocaleDateString() , //requested on
      deliveryType: this.deliveryType,
      fullfilledDate: this.fullfilledDate,
      orderNum: this.orderNum,
      price: this.price,
      description: this.description,
      payment: this.payment,
      tierCount: this.tierCount,
      servings: this.servings,
      flavorCake: this.flavorCake,
      flavorFrosting: this.flavorFrosting,
      fillings: this.fillings
    }
  ]
  states: string[] = [
    'KY', 'IN', 'TN', 'OH'
  ];

  submit() {
    this.emailEdit = false;
    this.addressEdit = false;
    this.phoneEdit = false;
  }
  editPhone() {
    this.phoneEdit = true;
  }
  editAddress() {
    this.addressEdit = true;
  }
  editEmail() {
    this.emailEdit = true;
  }

  openEditOrder(o: any): void {
    const dialogRef = this.dialog.open(OrderEditComponent, {
      width: '700px',
      height: '80%',
      data:
      {
        address1: o.address1,
        address2: o.address2,
        city: o.city,
        state: o.state,
        zip: o.zip,

        deliveryDate: o.deliveryDate,
        deliveryType: o.deliveryType,
      }
    });

    dialogRef.componentInstance.onCancel.subscribe( cancel => {
      cancel ? dialogRef.close() : null;
      return;
    })

    dialogRef.componentInstance.onSubmit.subscribe(data => {
      console.log("data on account sub")
      console.log(data)
      this.deliveryDate = data.deliveryDate;
      this.deliveryType = data.deliveryType;
      return;
    })
  }

}