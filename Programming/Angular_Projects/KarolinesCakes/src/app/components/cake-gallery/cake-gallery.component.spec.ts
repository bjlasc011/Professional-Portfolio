import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CakeGalleryComponent } from './cake-gallery.component';

describe('CakeGalleryComponent', () => {
  let component: CakeGalleryComponent;
  let fixture: ComponentFixture<CakeGalleryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CakeGalleryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CakeGalleryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
