export interface PagedList<TData> {
    pageNumber: number;
    totalPages: number;
    totalCount: number;
    isFirstPage: boolean;
    isLastPage: boolean;
    count: number;
    data: TData[];
}
