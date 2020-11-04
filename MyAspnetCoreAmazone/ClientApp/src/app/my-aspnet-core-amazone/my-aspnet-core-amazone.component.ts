import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { MyAspnetCoreAmazoneService } from '../my-aspnet-core-amazone.service';
import { ProductViewModel } from '../product-view-model';
import { DxDataGridComponent } from 'devextreme-angular';
import { ProductListRequest, CustomerType } from '../product-list-request';

@Component({
  selector: 'app-my-aspnet-core-amazone',
  templateUrl: './my-aspnet-core-amazone.component.html',
  styleUrls: ['./my-aspnet-core-amazone.component.css'],
})
export class MyAspnetCoreAmazoneComponent implements OnInit, AfterViewInit {
  @ViewChild('MyAmazoneEcommerceDataGrid', { static: false })
  MyAmazoneEcommerceDataGrid: DxDataGridComponent;
  public ProductViewModel: ProductViewModel[];
  constructor(
    private _myAspnetCoreAmazoneService: MyAspnetCoreAmazoneService
  ) {}
  ngAfterViewInit(): void {
    this.MyAmazoneEcommerceDataGrid.instance.beginCustomLoading(
      'Grid Data is being load...'
    );
    console.log('inside ngAfterViewInit');
    const productListRequest = new ProductListRequest();
    productListRequest.CustomerType = CustomerType.Standard;
    this._myAspnetCoreAmazoneService
      .GetAllProductsFor(productListRequest)
      .subscribe(
        (result) => {
          this.ProductViewModel = result.Products;
          this.MyAmazoneEcommerceDataGrid.instance.endCustomLoading();
          console.log('data from server load with success..');
          console.log(this.ProductViewModel);
          console.log('all data from server');
          console.log(result);
        },
        (error) => console.error(error)
      );
  }

  ngOnInit() {}
}
