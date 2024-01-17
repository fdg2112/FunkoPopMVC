namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            CART = new HashSet<CART>();
            SALE_DETAIL = new HashSet<SALE_DETAIL>();
        }

        [Key]
        public int idProduct { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(999)]
        public string description { get; set; }

        public decimal? price { get; set; }

        public int stock { get; set; }

        public bool shine { get; set; }

        public int? idCollection { get; set; }

        public bool active { get; set; }

        [StringLength(400)]
        public string url_image { get; set; }

        [StringLength(100)]
        public string ref_image { get; set; }

        public DateTime? registerdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART> CART { get; set; }

        public virtual COLLECTION COLLECTION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALE_DETAIL> SALE_DETAIL { get; set; }
    }
}
