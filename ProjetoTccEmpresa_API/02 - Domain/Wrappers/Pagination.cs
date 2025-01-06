namespace ProjetoTccEmpresa_API.Domain.Wrappers
{
    public class Pagination<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public T Records { get; set; }

        public Pagination(T records, int pageNumber, int pageSize, int totalRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            Records = records;
            TotalPages = (totalRecords % TotalPages == 0) ? (totalRecords / pageSize) : (totalRecords / pageSize);
        }
    }
}
