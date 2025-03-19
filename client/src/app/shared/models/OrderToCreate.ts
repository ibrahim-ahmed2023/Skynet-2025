import { PaymentSummary } from "./PaymentSummary";
import { ShippingAddress } from "./ShippingAddress";
  
export interface OrderToCreate {
  cartId: string;
  deliveryMethodId: number;
  shippingAddress: ShippingAddress;
  paymentSummary: PaymentSummary;
  discount?: number;
}