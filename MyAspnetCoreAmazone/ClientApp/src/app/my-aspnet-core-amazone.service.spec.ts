import { TestBed } from '@angular/core/testing';

import { MyAspnetCoreAmazoneService } from './my-aspnet-core-amazone.service';

describe('MyAspnetCoreAmazoneService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MyAspnetCoreAmazoneService = TestBed.get(MyAspnetCoreAmazoneService);
    expect(service).toBeTruthy();
  });
});
