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
import { TableColumn } from 'src/app/_infrastructure/models/TableColumn';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements AfterViewInit {

  pagedBooks: PagedResult<BookGridRow>;

  tableColumns: TableColumn[] = [
    { name: 'title', index: 'title', useInGlobalFiltering: true },
    { name: 'publisher', index: 'publisher.name', useInGlobalFiltering: true },
    { name: 'publishedOn', index: 'publishedOn' },
    { name: 'price', index: 'price' },
    { name: 'id', index: 'id' }
  ];

  displayedColumns: string[];

  globalFilterInput = new FormControl('');

  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false}) sort: MatSort;

  constructor(
    private bookService: BookService,
    public dialog: MatDialog,
    public snackBar: MatSnackBar
  ) {
    this.displayedColumns = this.tableColumns.map(column => column.name);
  }

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
    const filterValue = this.globalFilterInput.value.trim();
    if (filterValue) {
      const filters: Filter[] = [];
      this.tableColumns.forEach(column => {
        if (column.useInGlobalFiltering) {
          const filter: Filter = { path : column.index, value : filterValue };
          filters.push(filter);
        }
      });
      return filters;
    }
  }

}
