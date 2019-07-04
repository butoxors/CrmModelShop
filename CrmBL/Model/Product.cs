using System.Collections.Generic;

namespace CrmBL.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public int Count { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Sell> Sells { get; set; }

        public override string ToString() => Name;
    }
}
