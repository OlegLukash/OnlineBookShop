import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Book } from '../_models/Book';
import { Observable } from 'rxjs';
import { PagedResult } from '../_infrastructure/models/PagedResult';

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

  getBooksPaged(pageIndex: number, pageSize: number, columnNameForSorting: string, sortDirection: string): Observable<PagedResult<Book>> {
    return this.http.get<PagedResult<Book>>(this.baseUrl + 'books', {
      params: new HttpParams()
          .set('pageIndex', pageIndex.toString())
          .set('pageSize', pageSize.toString())
          .set('columnNameForSorting', columnNameForSorting)
          .set('sortDirection', sortDirection)
    });
  }

  getBook(id: number): Observable<Book> {
    return this.http.get<Book>(this.baseUrl + 'books/' + id);
  }

  saveBook(book: Book): Observable<Book> {
    if (book.id > 0) {
      return this.updateBook(book);
    }
    return this.createBook(book);
  }

  deleteBook(id: number) {
    return this.http.delete(this.baseUrl + 'books/' + id);
  }

  private updateBook(book: Book): Observable<Book> {
    return this.http.put<Book>(this.baseUrl + 'books/' + book.id, book);
  }

  private createBook(book: Book): Observable<Book> {
    return this.http.post<Book>(this.baseUrl + 'books/', book);
  }

}
