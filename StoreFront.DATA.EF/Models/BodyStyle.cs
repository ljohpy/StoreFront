using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class BodyStyle
    {
        public BodyStyle()
        {
            Cars = new HashSet<Car>();
        }

        public int StyleId { get; set; }
        public string StyleName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
