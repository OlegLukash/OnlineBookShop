/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { PublisherService } from './publisher.service';

describe('Service: Publisher', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PublisherService]
    });
  });

  it('should ...', inject([PublisherService], (service: PublisherService) => {
    expect(service).toBeTruthy();
  }));
});
