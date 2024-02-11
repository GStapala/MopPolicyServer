import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PolicyAdminComponent } from './policy-admin.component';

describe('PolicyAdminComponent', () => {
  let fixture: ComponentFixture<PolicyAdminComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PolicyAdminComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PolicyAdminComponent);
    fixture.detectChanges();
  });

  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    expect(titleText).toEqual('Policy Administrator');
  }));
});
