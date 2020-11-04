import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyAspnetCoreAmazoneComponent } from './my-aspnet-core-amazone.component';

describe('MyAspnetCoreAmazoneComponent', () => {
  let component: MyAspnetCoreAmazoneComponent;
  let fixture: ComponentFixture<MyAspnetCoreAmazoneComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyAspnetCoreAmazoneComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyAspnetCoreAmazoneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
