using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineQuize.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QId { get; set; }

       [Display(Name ="Question")]
        [Required(ErrorMessage = "Enter Quetion")]
        
        public string QName { get; set; }
        [Required(ErrorMessage = "Enter Option")]
        [Display(Name = "A")]
        public string OpA { get; set; }
        [Required(ErrorMessage = "Enter Option")]
        [Display(Name = "B")]
        public string OpB { get; set; }
        [Required(ErrorMessage = "Enter Options")]
        [Display(Name = "C")]
        public string OpC { get; set; }
        [Required(ErrorMessage = "Enter Options")]
        [Display(Name = "D")]
        public string OpD { get; set; }
        [Required(ErrorMessage = "Enter Answer")]
        [Display(Name = "Currect Answer")]
        public string CuurectAns{ get; set; }
        [Display(Name ="Category")]
        public int CatId { get; set; }
        [ForeignKey("CatId")]
        public virtual Category Categories { get; set; }


    }
}