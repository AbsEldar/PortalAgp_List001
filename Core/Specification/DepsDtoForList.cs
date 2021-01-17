using Core.Entities;

namespace Core.Specification
{
    public class DepsDtoForList:  BaseSpecification<Department>
    {
        public DepsDtoForList()
        {
            AddOrderBy(x => x.Name);
        }
    }
}