namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCT")]
    public partial class Product
    {
        public Product()
        {
            CART = new HashSet<Cart>();
            SALE_DETAIL = new HashSet<Sale_Detail>();
        }

        [Key]
        public int IdProduct { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(999)]
        public string Description { get; set; }

        public decimal? Price { get; set; }
        public string PriceText { get; set; }

        public int Stock { get; set; }

        public bool Shine { get; set; }

        public int? IdCollection { get; set; }

        public bool Active { get; set; }

        [StringLength(400)]
        public string Url_image { get; set; }

        [StringLength(100)]
        public string Ref_image { get; set; }

        public string Base64 { get; set; }
        public string Extension { get; set; }

        public DateTime? RegisterDate { get; set; }

        public virtual ICollection<Cart> CART { get; set; }

        public virtual Collection COLLECTION { get; set; }

        public virtual ICollection<Sale_Detail> SALE_DETAIL { get; set; }
    }
}
