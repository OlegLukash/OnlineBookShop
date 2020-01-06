import { Component, ViewChild, AfterViewInit } from '@angular/core';

import { Book } from '../../../_models/Book';
import { BookService } from '../../../_services/book.service';

import {
  MatDialog,
  MatSnackBar,
  MatPaginator,
  MatTableDataSource,
  MatSort
} from '@angular/material';
import { ConfirmDialogComponent } from 'src/app/admin/shared/confirm-dialog.component';
import { PagedResult } from 'src/app/_infrastructure/models/PagedResult';
import { merge } from 'rxjs';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements AfterViewInit {

  pagedBooks: PagedResult<Book>;

  displayedColumns: string[] = ['title', 'publisher', 'publishedOn', 'price', 'id'];

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false}) sort: MatSort;

  constructor(
    private bookService: BookService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar
  ) { }

  ngAfterViewInit() {
    this.loadBooksFromApi();

    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);

    merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
      this.loadBooksFromApi();
    });
  }

  loadBooksFromApi() {
    this.bookService.getBooksPaged(this.paginator.pageIndex, this.paginator.pageSize, this.sort.active, this.sort.direction)
      .subscribe((pagedBooks: PagedResult<Book>) => {
        this.pagedBooks = pagedBooks;
      });
  }

  openDialogForDeleting(id: number) {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { title: 'Dialog', message: 'Are you sure to delete this item?' }
    });
    dialogRef.disableClose = true;

    dialogRef.afterClosed().subscribe(result => {
      if (result === dialogRef.componentInstance.ACTION_CONFIRM) {
        this.bookService.deleteBook(id).subscribe(
          () => {
            this.loadBooksFromApi();

            this.snackBar.open('The item has been deleted successfully.', 'Close', {
              duration: 1500
            });
          }
        );
      }
    });

  }

}
