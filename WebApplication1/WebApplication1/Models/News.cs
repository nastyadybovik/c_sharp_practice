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
        public int Author { get; set; }


        public int AuthorId { get; set; }

        [DataType(DataType.DateTime)]
        public DataType CreationDate { get; set; }
    }
}