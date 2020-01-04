import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from 'src/app/_services/book.service';
import { Book } from 'src/app/_models/Book';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-editBook',
  templateUrl: './editBook.component.html',
  styleUrls: ['./editBook.component.css']
})
export class EditBookComponent implements OnInit {

  public book: Book;
  public bookForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private bookService: BookService
  ) { }

  ngOnInit() {

    this.bookForm = this.formBuilder.group({
      title: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
      description: ['', Validators.minLength(5)],
      publishedOn: [new Date(), [Validators.required]],
      publisher: ['', [Validators.required]],
      price: ['', [Validators.required]]
    });


    this.route.params.subscribe(params => {
      const id = +params['id'];
      this.getBook(id);
    });
  }

  getBook(id: number): void {
    this.bookService.getBook(id).subscribe((book: Book) => {
      this.book = book;
      this.bookForm.patchValue({
        title: this.book.title,
        description: this.book.description,
        publishedOn: this.book.publishedOn,
        publisher: this.book.publisher,
        price: this.book.price
      });

    });
  }

  saveBook(): void {
    if (this.bookForm.dirty && this.bookForm.valid) {
       const book = Object.assign({}, this.book, this.bookForm.value);
       this.bookService.saveBook(book).subscribe(
         () => this.onSaveComplete()
       );
    }
  }

  onSaveComplete(): void {
    // Reset the form to clear the flags
    this.bookForm.reset();
    this.router.navigate(['/admin/books']);
  }

}
