namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COLLECTION")]
    public partial class Collection
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Collection()
        {
            PRODUCT = new HashSet<Product>();
        }

        [Key]
        public int idCollection { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        [Required]
        [StringLength(999)]
        public string description { get; set; }

        public bool? active { get; set; }

        [StringLength(400)]
        public string url_image { get; set; }

        [StringLength(100)]
        public string ref_image { get; set; }

        public DateTime? registerdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> PRODUCT { get; set; }
    }
}
