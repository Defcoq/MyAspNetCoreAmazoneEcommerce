export class ProductListRequest {
  public CustomerType: CustomerType;
}

export enum CustomerType {
  Standard = 0,
  Trade = 1,
}
