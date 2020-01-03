import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BookService } from 'src/app/_services/book.service';
import { Book } from 'src/app/_models/Book';

@Component({
  selector: 'app-editBook',
  templateUrl: './editBook.component.html',
  styleUrls: ['./editBook.component.css']
})
export class EditBookComponent implements OnInit {

  private book: Book;

  constructor(
    private route: ActivatedRoute,
    private bookService: BookService
  ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      const id = +params['id'];
      this.getBook(id);
    });
  }

  getBook(id: number): void {
    this.bookService.getBook(id).subscribe((book: Book) => {
      this.book = book;
    });
  }

}
