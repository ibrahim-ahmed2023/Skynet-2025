import { Component, inject, Input } from '@angular/core';
import { CurrencyPipe } from '@angular/common';
import { ConfirmationToken } from '@stripe/stripe-js';
import { AddressPipe } from '../../../shared/pipes/adress.pipe';
import { PaymentCardPipe } from '../../../shared/pipes/payment-card.pipe';
import { CartService } from '../../../core/services/cart.service';

@Component({
  selector: 'app-checkout-review',
  standalone: true,
  imports: [
    CurrencyPipe,
    AddressPipe,
    PaymentCardPipe,
],
  templateUrl: './checkout-review.component.html',
  styleUrl: './checkout-review.component.scss'
})
export class CheckoutReviewComponent {
  cartService = inject(CartService);
  @Input() confirmationToken?: ConfirmationToken;
}