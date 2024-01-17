namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CART")]
    public partial class CART
    {
        [Key]
        public int idCart { get; set; }

        public int? idClient { get; set; }

        public int? idProduct { get; set; }

        public int? amount { get; set; }

        public virtual CLIENT CLIENT { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
