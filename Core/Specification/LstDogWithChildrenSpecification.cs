using System;
using Core.Entities;

namespace Core.Specification
{
    public class LstDogWithChildrenSpecification: BaseSpecification<LstDog>
    {
        public LstDogWithChildrenSpecification(string sort)
        {
            AddInclude(x => x.Childrens);
            AddOrderBy(x => x.Name);

            // if(!string.IsNullOrEmpty(sort))
            // {
            //     switch(sort)
            //     {
            //         case "priceAsc":
            //             AddOrderBy(p => p.Name);
            //             break;
            //         default:
            //             AddOrderBy(n => n.Name);
            //             break;
            //     }
            // }
        }

        public LstDogWithChildrenSpecification(Guid id): base(x => x.Id == id)
        {
            AddInclude(x => x.Childrens);
        }
    }
}