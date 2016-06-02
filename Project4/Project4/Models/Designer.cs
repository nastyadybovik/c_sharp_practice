using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project4.Models
{
    public class Designer
    {
        public int Id { set; get; }

        [Required]
        [Display(Name = "Name")]
        public String Name { set; get; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public String Email { set; get; }

        public List<Clothes> clothesList { set; get; }
    }
}