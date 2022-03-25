using System;
using System.Collections.Generic;

namespace CAFE.DATA.Entity
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Categoryid { get; set; }
        public string Categoryname { get; set; }
        public int? Parentcategoryid { get; set; }
        public bool? Isdeleted { get; set; }
        public DateTime? Createddate { get; set; }
        public int? Creatoruserid { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
