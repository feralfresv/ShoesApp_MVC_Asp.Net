//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoesApp2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Qualification
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdRating { get; set; }
        public int Count { get; set; }
        public System.DateTime DateUpdate { get; set; }
    
        public virtual CatRatings CatRatings { get; set; }
        public virtual Products Products { get; set; }
    }
}
