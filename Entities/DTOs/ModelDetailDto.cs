using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ModelDetailDto : IDto
    {
        public int ModelId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
