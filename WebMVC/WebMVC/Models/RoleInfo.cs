using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static WebMVC.Models.EnumType;

namespace WebMVC.Models
{
    [Table("RoleInfo")]
    /// <summary>
    /// 角色
    /// </summary>
    public class RoleInfo
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int _Id { get; set; }

        [Key]
        public string Id { get; set; }

        [MaxLength(50, ErrorMessage = "")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "")]
        public string Description { get; set; }

        public DelflagType Delflag { get; set; }

        public DateTime CDate { get; set; }
    }
}