import { ProductViewModel } from './product-view-model';

export interface ProductListResponse {
  Success: boolean;
  Message: string;
  Products: ProductViewModel[];
}
