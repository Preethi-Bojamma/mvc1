using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc1.Models
{
    public class MovieB
    {
        public int ID { get; set; }

        [Required]
        [Column(TypeName="varchar")]
        [Display(Name="Movie Name")]
        [StringLength(100)]
        public string Name{ get; set; }


        [Required]
       
        [Display(Name = "Releasing Date")]
       public DateTime ReleaseDate { get; set; }
        //public string Genre{ get; set; }

        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [Required]
        public string AvailableStock { get; set; }
    }
}