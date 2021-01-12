namespace Core.Specification
{
    public class DepartmentSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 0;
        private int _pagSize = 10;
        public int PageSize 
        {
            get => _pagSize; 
            set => _pagSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
 
        public string Sort { get; set; }
        private string _search;
        public string Search { 
            get => _search;
            set => _search = value.ToLower(); 
        }

    }
}