using System;
using System.Collections.Generic;

namespace CAFE.DATA.Entity
{
    public partial class Productproperty
    {
        public int Productpropertyid { get; set; }
        public int? Productid { get; set; }
        public int? Propertyid { get; set; }

        public virtual Product Product { get; set; }
        public virtual Property ProductpropertyNavigation { get; set; }
    }
}
