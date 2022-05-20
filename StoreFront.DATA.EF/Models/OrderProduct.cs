using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class OrderProduct
    {
        public int OrderProductId { get; set; }
        public int CarId { get; set; }
        public int OrderId { get; set; }
        public short? Quanity { get; set; }
        public decimal? ProductPrice { get; set; }

        public virtual Car Car { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
