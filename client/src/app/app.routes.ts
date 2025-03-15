import { Routes } from '@angular/router';
import { HomeComponent } from './features/home/home.component';
import { ShopComponent } from './features/shop/shop.component';
import { ProductDetailsComponent } from './features/shop/product-details/product-details.component';
import { TestErrorComponent } from './features/test-error/test-error.component';
import { NotFoundComponent } from './shared/compomemts/not-found/not-found.component';
import { ServerErrorComponent } from './shared/compomemts/server-error/server-error.component';
import { ContactsComponent } from './features/contacts/contacts.component';
import { CartComponent } from './features/cart/cart.component';
import { CheckoutComponent } from './features/checkout/checkout.component';

export const routes: Routes = [
    {path: '' , component: HomeComponent},
    {path: 'shop' , component: ShopComponent},
    {path: 'shop/:id' , component: ProductDetailsComponent},
    {path: 'cart' , component: CartComponent},
    {path: 'test-error' , component: TestErrorComponent},
    {path: 'checkout', component: CheckoutComponent},
    {path: 'not-found' , component: NotFoundComponent},
    {path: 'server-error' , component: ServerErrorComponent},
    {path: 'contacts' , component: ContactsComponent},
    {path: '**' , redirectTo: 'not-found' , pathMatch: 'full'}
];
