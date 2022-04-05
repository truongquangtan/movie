using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project1.Models {
    public class Movie {
        public int ID {set; get;}
        public string Title {set; get;}
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate {set; get;}
        public string Genre {set ;get;}
        [Column(TypeName = "Decimal(18,2)")]
        public Decimal Price {set; get;}
    }
}