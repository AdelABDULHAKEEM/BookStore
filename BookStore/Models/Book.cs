using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BookStore.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
       
        [Required]
        [MaxLength(20, ErrorMessage = "Error > 20")]
        [MinLength(5, ErrorMessage = "Error < 5")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You Must Fill This Filed")]
        public int Pages { get; set; }

        [Required(ErrorMessage = "You Must Fill This Filed")]
        public string Author { get; set; }

    }

   
}