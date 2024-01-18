namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CLIENT")]
    public partial class Client
    {
        public Client()
        {
            CART = new HashSet<Cart>();
            SALE = new HashSet<Sale>();
        }

        [Key]
        public int IdClient { get; set; }

        [Required]
        [StringLength(100)]
        public string Lastname { get; set; }

        [Required]
        [StringLength(100)]
        public string Firstname { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Password { get; set; }

        public bool? Reboot { get; set; }

        public DateTime? Registerdate { get; set; }

        public virtual ICollection<Cart> CART { get; set; }

        public virtual ICollection<Sale> SALE { get; set; }
    }
}
