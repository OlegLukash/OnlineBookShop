import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BookService } from 'src/app/_services/book.service';
import { Book } from 'src/app/_models/Books/Book';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PublisherService } from 'src/app/_services/publisher.service';
import { Publisher } from 'src/app/_models/Publishers/Publisher';
import * as _ from 'lodash';

@Component({
  selector: 'app-editBook',
  templateUrl: './editBook.component.html',
  styleUrls: ['./editBook.component.css']
})
export class EditBookComponent implements OnInit {

  public pageTitle: string;
  public book: Book;
  public publishers: Publisher[];
  public bookForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder,
    private bookService: BookService,
    private publisherService: PublisherService
  ) { }

  ngOnInit() {

    this.bookForm = this.formBuilder.group({
      title: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(200)]],
      description: ['', Validators.minLength(5)],
      publishedOn: ['', [Validators.required]],
      publisherId: ['', [Validators.required]],
      price: ['', [Validators.required]]
    });

    this.getAllPublishers();

    this.route.params.subscribe(params => {
      const id = +params['id'];
      if (id === 0) {
        this.pageTitle = 'Add Book:';
      } else {
        this.getBook(id);
        this.pageTitle = 'Edit Book:';
      }
    });
  }

  getAllPublishers(): void {
    this.publisherService.getAllPublishers().subscribe((publishers: Publisher[]) => {
      this.publishers = _.orderBy(publishers, 'name');
    });
  }

  getBook(id: number): void {
    this.bookService.getBook(id).subscribe((book: Book) => {
      this.book = book;
      this.bookForm.patchValue({
        title: this.book.title,
        description: this.book.description,
        publishedOn: this.book.publishedOn,
        publisherId: this.book.publisherId,
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
