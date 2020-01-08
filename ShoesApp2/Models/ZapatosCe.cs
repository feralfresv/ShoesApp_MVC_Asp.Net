using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoesApp2.Models
{
    public class ZapatosCE
    {
        public int Id { get; set; }
        public Nullable<int> IdType { get; set; }
        [Required]
        [Display(Name = "Color")]
        public Nullable<int> IdColor { get; set; }
        public Nullable<int> IdBrand { get; set; }
        public Nullable<int> IdProvider { get; set; }
        public int IdCatalog { get; set; }
        public string Title { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public string Observations { get; set; }
        public Nullable<decimal> PriceDistributor { get; set; }
        [Required]
        [Display(Name = "Precio")]
        public decimal PriceClient { get; set; }
        public decimal PriceMember { get; set; }
        public bool IsEnabled { get; set; }
        public string Keywords { get; set; }
        public System.DateTime DateUpdate { get; set; }
    }


    [MetadataType(typeof(ZapatosCE))]
    public partial class FASV1_GetAllProducts_Result
    {

    }
}