using System;
using System.Collections.Generic;

namespace StoreFront.UI.MVC.Models
{
    public partial class ProductStatus
    {
        public ProductStatus()
        {
            Cars = new HashSet<Car>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
