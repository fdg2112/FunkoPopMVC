namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SALE_DETAIL
    {
        [Key]
        public int idSaleDetail { get; set; }

        public int? idSale { get; set; }

        public int? idProduct { get; set; }

        public int? amount { get; set; }

        public decimal? total { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }

        public virtual SALE SALE { get; set; }
    }
}
