using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project4.Models
{
    public class Clothes
    {
        public enum ClothesType { skirt, trousers, shirt, dress }

        public enum Size { X, M, L }

        public enum Material { cotton, jeans, fur }

        public enum Country { USA, England }

        public int Id { set; get; }

        [Required]
        [Display(Name = "Type")]
        public ClothesType Type { set; get; }

        [Required]
        [Display(Name = "Size")]
        public Size SizeName { set; get; }

        [Required]
        [Display(Name = "Material")]
        public Material MaterialName { set; get; }

        [Required]
        [Display(Name = "Price")]
        public Double Price { set; get; }

        [Required]
        [Display(Name = "Country")]
        public Country CountryName { set; get; }

        [Required]
        [Display(Name = "Description")]
        public String Description { set; get; }

     
        [Display(Name = "Designer")]
        public Designer Designer { set; get; }

        public String FileName { set; get; }

    }

    
}