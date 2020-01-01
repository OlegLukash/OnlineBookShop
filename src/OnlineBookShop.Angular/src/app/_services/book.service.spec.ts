/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BookService } from './book.service';

describe('Service: Book', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BookService]
    });
  });

  it('should ...', inject([BookService], (service: BookService) => {
    expect(service).toBeTruthy();
  }));
});
