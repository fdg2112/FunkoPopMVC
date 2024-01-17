namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [Key]
        public int idUser { get; set; }

        [Required]
        [StringLength(100)]
        public string lastname { get; set; }

        [Required]
        [StringLength(100)]
        public string firstname { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [StringLength(150)]
        public string password { get; set; }

        public bool? reboot { get; set; }

        public bool? active { get; set; }

        public DateTime? registerdate { get; set; }
    }
}
