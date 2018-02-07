using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class TestClass
    {
        public int KeyId { get; set; }
        [Key]
        public string Id { get; set; }
        [MaxLength(50, ErrorMessage = "")]
        public string Name { get; set; }
    }
}