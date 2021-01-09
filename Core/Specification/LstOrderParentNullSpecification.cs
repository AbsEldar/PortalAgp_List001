using Core.Entities;

namespace Core.Specification
{
    public class LstOrderParentNullSpecification: BaseSpecification<LstOrder>
    {
        public LstOrderParentNullSpecification(): base(x => x.ParentId == null)
        {
            // AddInclude(x => x.Childrens);
        }
    }
}