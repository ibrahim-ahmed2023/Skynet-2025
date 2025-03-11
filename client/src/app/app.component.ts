import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./layout/header/header.component";
import { HttpClient } from '@angular/common/http';
import { Product } from './shared/models/product';
import { pagination } from './shared/models/pagination';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {

  baseUrl = 'https://localhost:5001/api/';
  title = 'Skinet';
  private http = inject(HttpClient);
  products: Product[] = [];
  ngOnInit(): void {
    this.http.get<pagination<Product>>(this.baseUrl + 'products').subscribe({
      next : response => this.products = response.data,
      error: error => console.log(error),
      complete: () => console.log('complete')
    })
  }


}
