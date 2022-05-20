using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Car
    {
        public Car()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int CarId { get; set; }
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string Year { get; set; } = null!;
        public string ExteriorColor { get; set; } = null!;
        public string Miles { get; set; } = null!;
        public string VinNumber { get; set; } = null!;
        public string InteriorColor { get; set; } = null!;
        public string? Description { get; set; }
        public int StatusId { get; set; }
        public int StyleId { get; set; }

        public virtual ProductStatus Status { get; set; } = null!;
        public virtual BodyStyle Style { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
