namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CITY")]
    public partial class City
    {
        public City()
        {
            SALE = new HashSet<Sale>();
        }

        [Key]
        public int IdCity { get; set; }

        [Required]
        [StringLength(8)]
        public string Postal_code { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int IdProvince { get; set; }

        public virtual Province PROVINCE { get; set; }

        public virtual ICollection<Sale> SALE { get; set; }
    }
}
