using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    [Table("CodeFirstTestModel")]
    public class CodeFirstTestModel
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int _id { get; set; }
        [Key]
        public string Id { get; set; }
        [MaxLength(200, ErrorMessage = "")]
        [DefaultValue("")]
        public string TestName { get; set; }
        [MaxLength(200, ErrorMessage = "")]
        [DefaultValue("")]
        public string Name { get; set; }
        [MaxLength(200, ErrorMessage = "")]
        [DefaultValue("")]
        public string Namerr { get; set; }
    }
}