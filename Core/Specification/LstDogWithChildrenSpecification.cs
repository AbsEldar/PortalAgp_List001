using System;
using Core.Entities;

namespace Core.Specification
{
    public class LstDogWithChildrenSpecification: BaseSpecification<LstDog>
    {
        public LstDogWithChildrenSpecification()
        {
            AddInclude(x => x.Childrens);
        }

        public LstDogWithChildrenSpecification(Guid id): base(x => x.Id == id)
        {
            AddInclude(x => x.Childrens);
        }
    }
}