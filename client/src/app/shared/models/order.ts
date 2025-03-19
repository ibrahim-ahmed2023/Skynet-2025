import { OrderItem } from "./OrderItem"
import { PaymentSummary } from "./PaymentSummary"
import { ShippingAddress } from "./ShippingAddress"

export interface Order {
  id: number
  orderDate: string
  buyerEmail: string
  shippingAddress: ShippingAddress
  deliveryMethod: string
  shippingPrice: number
  paymentSummary: PaymentSummary
  orderItems: OrderItem[]
  subtotal: number
  discount?: number
  status: string
  total: number
  paymentIntentId: string
}
