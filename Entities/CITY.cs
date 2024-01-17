namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CITY")]
    public partial class CITY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CITY()
        {
            SALE = new HashSet<SALE>();
        }

        [Key]
        public int idCity { get; set; }

        [Required]
        [StringLength(8)]
        public string postal_code { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int idProvince { get; set; }

        public virtual PROVINCE PROVINCE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALE> SALE { get; set; }
    }
}
