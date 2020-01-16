import { Component, ViewChild, AfterViewInit } from '@angular/core';

import { BookGridRow } from '../../../_models/Books/BookGridRow';
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
import { PaginatedRequest } from 'src/app/_infrastructure/models/PaginatedRequest';
import { Filter } from 'src/app/_infrastructure/models/Filter';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements AfterViewInit {

  pagedBooks: PagedResult<BookGridRow>;

  displayedColumns: string[] = ['title', 'publisher', 'publishedOn', 'price', 'id'];
  columnsForGlobalFiltering: string[] = ['title', 'publisher'];

  globalFilterInput = new FormControl('');

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
    const filters = this.createFilters();
    const paginatedRequest = new PaginatedRequest(this.paginator, this.sort, filters);
    this.bookService.getBooksPaged(paginatedRequest)
      .subscribe((pagedBooks: PagedResult<BookGridRow>) => {
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

  applyFilter() {
    this.loadBooksFromApi();
  }

  private createFilters(): Filter[] {
    const filterValue = this.globalFilterInput.value.trim(); // Remove whitespace
    const filters: Filter[] = [];
    this.columnsForGlobalFiltering.forEach(columnName => {
      const filter: Filter = { property : columnName, value : filterValue };
      filters.push(filter);
    });
    return filters;
  }

}
