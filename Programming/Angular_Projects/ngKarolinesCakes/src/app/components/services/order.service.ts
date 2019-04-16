import { Itreat } from '../orders/orders.component';

export class OrderService {
  order: Order;
}

export class Order {
  flavor: string;
  filling: string;
  frosting: string;
  treats: Itreat[];
}