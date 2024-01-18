namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROVINCE")]
    public partial class Province
    {
        public Province()
        {
            CITY = new HashSet<City>();
        }

        [Key]
        public int IdProvince { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public virtual ICollection<City> CITY { get; set; }
    }
}
