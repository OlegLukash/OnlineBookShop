import { MatSort, MatPaginator } from '@angular/material';

export class PaginatedRequest {
    pageIndex: number;
    pageSize: number;
    columnNameForSorting: string;
    sortDirection: string;

    constructor(paginator: MatPaginator, sort: MatSort) {
        this.pageIndex = paginator.pageIndex;
        this.pageSize = paginator.pageSize;
        this.columnNameForSorting = sort.active;
        this.sortDirection = sort.direction;
    }

}
