using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class FilmInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }
        [Key]
        public string Id { get; set; }
        public int FilmId { get; set; }
        public string FilmName { get; set; }
    }
}