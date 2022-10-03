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
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CId { get; set; }

        [Display(Name = "Category Name")]
        [Required(ErrorMessage = "Enter Category name")]
        public string CName { get; set; }
        public string EncName { get; set; }
        public int AdminId { get; set; }
        [ForeignKey("AdminId")]
        public virtual Admin Admins { get; set; }
    }
}