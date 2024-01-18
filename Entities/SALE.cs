namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SALE")]
    public partial class Sale
    {
        public Sale()
        {
            SALE_DETAIL = new HashSet<Sale_Detail>();
        }

        [Key]
        public int IdSale { get; set; }

        public int? IdClient { get; set; }

        public int? Amount_products { get; set; }

        public decimal? Payment_total { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        public int? IdCity { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Address { get; set; }

        [StringLength(50)]
        public string IdTransaction { get; set; }

        public DateTime? SaleDate { get; set; }

        public virtual City CITY { get; set; }

        public virtual Client CLIENT { get; set; }

        public virtual ICollection<Sale_Detail> SALE_DETAIL { get; set; }
    }
}
