//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebFilm.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Table_CaTaLog
    {
        public int IDCatalog { get; set; }
        public string NameCatalog { get; set; }
        public string NameAscii { get; set; }
        public Nullable<int> IDUserName { get; set; }
    
        public virtual Table_Username Table_Username { get; set; }
    }
}
