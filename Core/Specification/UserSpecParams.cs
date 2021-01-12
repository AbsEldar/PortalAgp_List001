using System;

namespace Core.Specification
{
    public class UserSpecParams
    {
        private const int MaxPageSize = 150;
        public int PageIndex { get; set; } = 1;
        private int _pagSize = 100;
        public int PageSize 
        {
            get => _pagSize; 
            set => _pagSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public Guid? DepartmentId {get; set;}
 
        public string Sort { get; set; }
        private string _search;
        public string Search { 
            get => _search;
            set => _search = value.ToLower(); 
        }
    }
}