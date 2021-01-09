using System;
using System.Collections.Generic;
using Core.Enums;

namespace API.Dtos.Lsts
{
    public class LstDogToReturnDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string KeyIndex { get; set; }
        public LstTypeItem LstTypeItem { get; set; }
        public LstTypeClass LstTypeClass { get; set; }
        public bool IsDeleted { get; set; } = false;
        public IReadOnlyList<LstDogToReturnDto> Childrens { get; set; }
    }
}