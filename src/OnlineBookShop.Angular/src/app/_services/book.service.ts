import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Book } from '../_models/Book';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BookService {

  baseUrl = environment.apiUrl;

  constructor(
    private http: HttpClient
  ) { }

  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(this.baseUrl + 'books');
  }

  getBook(id: number): Observable<Book> {
    return this.http.get<Book>(this.baseUrl + 'books/' + id);
  }

}
