using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc1.Models
{
    public class customer
    {
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [Display(Name="Your Name")]
        [StringLength (50)]
        public string CName{ get; set; }


        [Required]
        [Display(Name ="Date of Birth")]
        public DateTime? BirthDate { get; set; }


        [Required]
        [Column(TypeName="char")]
        [StringLength(8)]
        public string Gender { get; set; }


        [Required]
        [Column(TypeName = "varchar")]
        [Display(Name = "Your City")]
        [StringLength(100)]

        public string City { get; set; }

        //reference class
        public MembershipType MembershipType { get; set; }

        //reference table column
        [Required]
        public int? MembershipTypeId { get; set; }
    }
}