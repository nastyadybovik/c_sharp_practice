using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class News
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Required field!")]

        public String Title { get; set; }

        public String Context { get; set; }

        [Display(Name="Perfect Author")]
        public Author Author { get; set; }

        [DataType(DataType.DateTime)]
        public DataType CreationDate { get; set; }

        public List<Tag> Tags { get; set; }
    }
}