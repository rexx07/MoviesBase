import {ComponentFixture, TestBed} from '@angular/core/testing';

import {PosterCardViewComponent} from './poster-card.component';

describe('PosterCardViewComponent', () => {
  let component: PosterCardViewComponent;
  let fixture: ComponentFixture<PosterCardViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PosterCardViewComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(PosterCardViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
