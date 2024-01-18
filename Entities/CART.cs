namespace Enities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CART")]
    public partial class Cart
    {
        [Key]
        public int IdCart { get; set; }

        public int? IdClient { get; set; }

        public int? IdProduct { get; set; }

        public int? Amount { get; set; }

        public virtual Client CLIENT { get; set; }

        public virtual Product PRODUCT { get; set; }
    }
}
