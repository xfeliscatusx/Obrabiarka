//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Obrabiarka
{
    using System;
    using System.Collections.Generic;
    
    public partial class Narzedzia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Narzedzia()
        {
            this.RodzajeNarzedzis = new HashSet<RodzajeNarzedzi>();
        }
    
        public int id_narzedzia { get; set; }
        public string grupa_narzedzi { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RodzajeNarzedzi> RodzajeNarzedzis { get; set; }
    }
}
