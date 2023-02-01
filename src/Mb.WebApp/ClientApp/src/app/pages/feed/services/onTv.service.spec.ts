import {inject, TestBed} from '@angular/core/testing';
import {OnTvService} from "./onTv.service";

describe('OnTVService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [OnTvService]
    });
  });

  it('should be created', inject([OnTvService], (service: OnTvService) => {
    expect(service).toBeTruthy();
  }));
});
