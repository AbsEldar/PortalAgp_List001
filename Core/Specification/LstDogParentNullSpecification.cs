using Core.Entities;

namespace Core.Specification
{
    public class LstDogParentNullSpecification: BaseSpecification<LstDog>
    {
        public LstDogParentNullSpecification(): base(x => x.ParentId == null)
        {
            // AddInclude(x => x.Childrens);
        }
    }
}