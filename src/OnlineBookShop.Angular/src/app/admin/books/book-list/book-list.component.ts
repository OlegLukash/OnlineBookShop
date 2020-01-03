import { Component, OnInit } from '@angular/core';

import { Book } from '../../../_models/Book';
import { BookService } from '../../../_services/book.service';

import {
  MatDialog,
  MatSnackBar,
  MatPaginator,
  MatTableDataSource,
  MatSort
} from '@angular/material';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {

  books: Book[] = [];

  displayedColumns: string[] = ['title', 'publisher', 'publishedOn', 'price', 'id'];

  constructor(
    private bookService: BookService
  ) { }

  ngOnInit() {
    this.loadBooks();
  }

  loadBooks() {
    this.bookService.getBooks().subscribe((books: Book[]) => {
      this.books = books;
    });
  }

}
