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
        public Collection()
        {
            Product = new HashSet<Product>();
        }

        public Collection(string ref_image)
        {
            this.Ref_image = ref_image;
        }

        [Key]
        public int IdCollection { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(999)]
        public string Description { get; set; }

        public bool? Active { get; set; }

        [StringLength(400)]
        public string Url_image { get; set; }

        [StringLength(100)]
        public string Ref_image { get; set; }

        public DateTime? Registerdate { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
