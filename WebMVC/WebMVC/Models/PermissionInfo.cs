using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static WebMVC.Models.EnumType;

namespace WebMVC.Models
{
    [Table("PermissionInfo")]
    /// <summary>
    /// 权限信息
    /// </summary>
    public class PermissionInfo
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int _Id { get; set; }

        [Key]
        public string Id { get; set; }

        [MaxLength(50, ErrorMessage = "")]
        public string Controller { get; set; }

        [MaxLength(50, ErrorMessage = "")]
        public string Action { get; set; }

        [MaxLength(150, ErrorMessage = "")]
        public string ControllerDescription { get; set; }

        [MaxLength(150, ErrorMessage = "")]
        public string ActionDescription { get; set; }

        public DateTime CDate { get; set; }

        public DelflagType Delflag { get; set; }
    }
}