import { MatSort, MatPaginator } from '@angular/material';
import { Filter } from './Filter';

export class PaginatedRequest {
    pageIndex: number;
    pageSize: number;
    columnNameForSorting: string;
    sortDirection: string;
    filters: Filter[];

    constructor(paginator: MatPaginator, sort: MatSort, filters: Filter[]) {
        this.pageIndex = paginator.pageIndex;
        this.pageSize = paginator.pageSize;
        this.columnNameForSorting = sort.active;
        this.sortDirection = sort.direction;
        this.filters = filters;
    }

}
