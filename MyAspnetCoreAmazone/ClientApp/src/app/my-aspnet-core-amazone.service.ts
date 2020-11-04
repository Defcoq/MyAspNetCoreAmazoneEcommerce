import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ProductListResponse } from './product-list-response';
import { Observable } from 'rxjs';
import { ProductListRequest } from './product-list-request';

@Injectable({
  providedIn: 'root',
})
export class MyAspnetCoreAmazoneService {
  constructor(private http: HttpClient) {}

  GetAllProductsFor(
    productListRequest: ProductListRequest
  ): Observable<ProductListResponse> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    console.log('inside GetAllProductsFor service method');
    console.log(JSON.stringify(productListRequest));
    // tslint:disable-next-line: max-line-length
    return this.http.post<ProductListResponse>(
      '/api/MyAspnetCoreAmazone/GetAllProductsFor',
      JSON.stringify(productListRequest),
      { headers: headers }
    );
  }
}
