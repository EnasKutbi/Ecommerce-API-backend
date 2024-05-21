public class QueryParameters
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
    public string SearchKeyword { get; set; } = "";
    public string SortBy { get; set; } = "Name";
    public string SortOrder { get; set; } = "asc";
}