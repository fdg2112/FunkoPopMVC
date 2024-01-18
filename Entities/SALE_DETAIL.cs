namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sale_Detail
    {
        [Key]
        public int IdSaleDetail { get; set; }

        public int? IdSale { get; set; }

        public int? IdProduct { get; set; }

        public int? Amount { get; set; }

        public decimal? Total { get; set; }

        public virtual Product PRODUCT { get; set; }

        public virtual Sale SALE { get; set; }
    }
}
