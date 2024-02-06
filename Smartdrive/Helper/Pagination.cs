namespace Smartdrive.Helper
{
    public class PaginationRequest
    {
        public string Search {  get; set; } = string.Empty;
        public int Limit { get; set; } = 10;
        public int Page { get; set; } = 1;

        public int Offset {
            get
            {
                return (Page - 1) * Limit;
            }
            set { }
        }
    }

    public class  PaginationResponse<T>: PaginationRequest where T : class
    {
        public PaginationResponse(PaginationRequest request) 
        { 
            this.Limit = request.Limit;
            this.Page = request.Page;
            this.Search = request.Search;
        }
        public List<T> Data { get; set; } = new List<T>();

        public int Count {  get; set; }
        public int TotalPage
        {
            get
            {
                return Count / Limit;
            }
            set { }
        }
    }
}
