using System;
using System.Collections.Generic;

namespace ChinsayVegteables.models
{
    public partial class VegeDetails
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long Qty { get; set; }
    }
}
