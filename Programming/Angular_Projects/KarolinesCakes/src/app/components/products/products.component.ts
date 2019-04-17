import { Component, OnInit } from '@angular/core';
import { FooterComponent } from '../footer/footer.component';
import { Router } from '@angular/router';
import { OrderService, Order } from '../services/order.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  shows: Array<boolean> = [];
  selected: Array<any> = [];
  order: Order;

  constructor(
    private router: Router,
    private orderService: OrderService
  ) { }

  ngOnInit() {
    this.categoriesWithPrices.forEach(cat => {
      this.shows.push(false);
    });
    this.order = this.orderService.order;
  }
  ngOnDestroy(){
    this.orderService.order = this.order;
    console.dir(this.order);
  }
  expand(i: number): void {
    this.shows[i] = !this.shows[i];
  }
  toggleChecked(i: number, j: number): void{
    this.categoriesWithPrices[i].flavors[j].checked = !this.categoriesWithPrices[i].flavors[j].checked;
    if(this.categoriesWithPrices[i].flavors[j].checked){
      this.selected.push(this.categoriesWithPrices[i].flavors[j])
    }
    else{
      this.selected.splice(
        this.selected.indexOf(this.categoriesWithPrices[i].flavors[j]), 1);
    }
    console.dir(this.selected)
  }
  pushOrders(){
      this.router.navigate(["orders"])
  }
  categoriesWithPrices: any[] = [
    {
      name: 'Serving Size Pricing',
      flavors: [
        {description: '6" cake (serves 12)', price: '$15.00 single / $25.00 double', checked: false },
        {description: '8" double layer (serves 20-25)', price: '$35.00', checked: false },
        {description: '10" (serves 28-35)', price: '$45.00', checked: false },
        {description: '10" and 6" dbouble stack (serves 40-45)', price: '$65.00', checked: false },
        {description: '1/4 sheet cake 9"x13" (serves 36)', price: '$35.00', checked: false },
        {description: '1/2 sheet cake 11"x15" (serves 54)', price: '$50.00', checked: false },
        {description: 'Full sheet cake (serves 72)', price: '$70.00', checked: false },
        {description: '*More serving sizes are available upon request', price:'', checked: false }
      ]
    },
    {
      name: 'Basic Cakes',
      flavors: [
        {description:'French Vanilla', price:'', checked: false },
        {description:'Chocolate', price:'', checked: false },
        {description:'Marble', price:'', checked: false },
        {description:'Strawberry', price:'', checked: false }
      ]
    },
    {
      name: 'Gluten Free',
      flavors: [
        {description: 'Vanilla*', price: '*add $.25 for cupcakes / $5 for each cake size', checked: false },
        {description: 'Chocolate*', price: '*add $.25 for cupcakes / $5 for each cake size', checked: false },
        {description: 'Carrot*', price: '*add $.25 for cupcakes / $5 for each cake size', checked: false },
        {description: 'Strawberry*', price: '*add $.25 for cupcakes / $5 for each cake size', checked: false },
        {description: 'Banana*', price: '*add $.25 for cupcakes / $5 for each cake size', checked: false },
      ]
    },
    {
      name: 'Premium Cakes',
      flavors: [
        {description:'Almond', price:'', checked: false },
        {description:'Amaretto', price:'', checked: false },
        {description:'Carrot', price:'', checked: false },
        {description:'Chocolate Chip', price:'', checked: false },
        {description:'Coconut', price:'', checked: false },
        {description:'Cookie Dough', price:'', checked: false },
        {description:'Cookies & Cream', price:'', checked: false }, 
        {description:'Italian Cream', price:'', checked: false },
        {description:'Banana', price:'', checked: false },
        {description:'Lemon', price:'', checked: false },
        {description:'Pancake', price:'', checked: false },  
        {description:'Pina Colada', price:'', checked: false },
        {description:'Pineapple', price:'', checked: false },
        {description:'Raspberry', price:'', checked: false },
        {description:'Red Velvet', price:'', checked: false }, 
        {description:'Spice', price:'', checked: false },
        {description:'White Chocolate', price:'', checked: false },
        {description:'Hummingbird', price:'', checked: false }
      ]
    },
    {
      name: 'Fillings',
      flavors: [
        {description:'Salted Caramel', price:'', checked: false },
        {description:'Fruit Preserves', price:'', checked: false },
        {description:'Lemon Curd', price:'', checked: false },
        {description:'Chocolate Ganache', price:'', checked: false },
        {description:'Marshmallow', price:'', checked: false },
        {description:'Peanut Butter Buttercream', price:'', checked: false },
        {description:'Lemon Cream Cheese Frosting', price:'', checked: false },
        {description:'Coconut Cream Cheese Frosting', price:'', checked: false }, 
        {description:'Strawbetty Cream Cheese Frosting', price:'', checked: false }, 
        {description:'Nutella', price:'', checked: false }
      ]
    },
    {
      name: 'Frosting Flavors',
      flavors: [
        {description:'Vanilla Buttercream', price:'', checked: false },
        {description:'Decorator Icing', price:'', checked: false },
        {description:'Chocolate Buttercream', price:'', checked: false },
        {description:'Almond Buttercream', price:'', checked: false },
        {description:'White Chocolate Buttercream', price:'', checked: false },
        {description:'Cream Cheese Frosting', price:'', checked: false }, 
        {description:'Peanut Butter Frosting', price:'', checked: false },
        {description:'Maple Buttercream', price:'', checked: false },
        {description:'Caramel Icing', price:'', checked: false },
        {description:'Brown Sugar Buttercream', price:'', checked: false },
        {description:'Marshmallow Buttercream', price:'', checked: false },
        {description:'Lemon Cream Cheese Frosting', price:'', checked: false }, 
        {description:'Raspberry Buttercream', price:'', checked: false },
        {description:'Coconut Cream Cheese Frosting', price:'', checked: false },
        {description:'Strawberry Cream Cheese Frosting', price:'', checked: false },
        {description:'Cookies & Cream', price:'', checked: false },
        {description:'Chocolate Ganache', price:'', checked: false }
      ]
    },
    {
      name: 'Seasonal Cakes',
      flavors: [
        {description:'Caramel Apple', price:'', checked: false },
        {description:'Pumpkin', price:'', checked: false },
        {description:'Pecan Pie', price:'', checked: false },
        {description:'Sugar Cookie', price:'', checked: false },
        {description:'Hot Chocolate', price:'', checked: false },
        {description:'Gingerbread', price:'', checked: false }
      ]
    },
    {
      name: 'Cupcakes',
      flavors: [
        {description:'Basic', price:'', checked: false },
        {description:'Premium', price:'', checked: false },
        {description:'Mini Cupcakes Basic', price:'', checked: false },
        {description:'Mini Cupcakes Premium', price:'', checked: false },
        {description:'Jumbo Cupcake', price:'', checked: false },
        {description:'Cupcake Cake / Smash Cake', price:'', checked: false }
      ]
    },
    {
      name: 'More Treats',
      flavors: [
        {description: 'Cookie Cake',price: '$20.00', checked: false },
        {description: '9" Pie',price: '$20.00', checked: false },
        {description: 'Cake Pops',price: '$1.50 (basic) / $1.75 (premium)', checked: false },
        {description: 'Cakes with Fresh Fruit', price: '$75.00 (fruit must be in season)', checked: false },
      ]
    }
  ];

  categories: any[] = []

}
