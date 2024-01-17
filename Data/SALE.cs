//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class SALE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SALE()
        {
            this.SALE_DETAIL = new HashSet<SALE_DETAIL>();
        }
    
        public int idSale { get; set; }
        public Nullable<int> idClient { get; set; }
        public Nullable<int> amount_products { get; set; }
        public Nullable<decimal> payment_total { get; set; }
        public string contact { get; set; }
        public Nullable<int> idCity { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string idTransaction { get; set; }
        public Nullable<System.DateTime> saleDate { get; set; }
    
        public virtual CITY CITY { get; set; }
        public virtual CLIENT CLIENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALE_DETAIL> SALE_DETAIL { get; set; }
    }
}
