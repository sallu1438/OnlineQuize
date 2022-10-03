using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineQuize.Models
{
    public class Set_Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter Exam Name")]
        [Display(Name ="Exam Name")]
        public string Exam_Name { get; set; }
        [Display(Name = "Exam Date")]
        public System.DateTime Exam_Date { get; set; }
        public int Score { get; set; }
        [Display(Name ="Scholar Name")]
        public int Scholar_Id { get; set; }
        [ForeignKey("Scholar_Id")]
        public virtual Scholar Schlors { get; set; }

    }
}