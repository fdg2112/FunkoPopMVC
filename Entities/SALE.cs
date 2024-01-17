namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SALE")]
    public partial class SALE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SALE()
        {
            SALE_DETAIL = new HashSet<SALE_DETAIL>();
        }

        [Key]
        public int idSale { get; set; }

        public int? idClient { get; set; }

        public int? amount_products { get; set; }

        public decimal? payment_total { get; set; }

        [StringLength(50)]
        public string contact { get; set; }

        public int? idCity { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(500)]
        public string address { get; set; }

        [StringLength(50)]
        public string idTransaction { get; set; }

        public DateTime? saleDate { get; set; }

        public virtual CITY CITY { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALE_DETAIL> SALE_DETAIL { get; set; }
    }
}
