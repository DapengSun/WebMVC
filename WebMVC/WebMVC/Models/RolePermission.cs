﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static WebMVC.Models.EnumType;

namespace WebMVC.Models
{
    [Table("RolePermission")]
    /// <summary>
    /// 角色权限对应
    /// </summary>
    public class RolePermission
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int _Id { get; set; }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int NumId { get; set; }

        [Key]
        public string Id { get; set; }

        [MaxLength(50,ErrorMessage ="")]
        public string RoleId { get; set; }

        [MaxLength(50, ErrorMessage = "")]
        public string PermissionId { get; set; }

        [MaxLength(50, ErrorMessage = "")]
        public string RoleName { get; set; }

        [MaxLength(50, ErrorMessage = "")]
        public string Controller { get; set; }

        [MaxLength(50, ErrorMessage = "")]
        public string Action { get; set; }


        [MaxLength(150, ErrorMessage = "")]
        public string ControllerDescription { get; set; }

        [MaxLength(150, ErrorMessage = "")]
        public string ActionDescription { get; set; }

        /// <summary>
        /// 该映射是否启用
        /// </summary>
        public UsedType UsedType { get; set; }

        public DelflagType Delflag { get; set; }

        public DateTime CDate {
            get; set;
        }
    }
}