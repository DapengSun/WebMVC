using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class UserProfile
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _id { get; set; }

        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 账户类型
        /// </summary>
        public EnumAccountType Role { get; set; }
        [NotMapped]
        public int RoleId {
            get {
                return (int)Role;
            }
        }

        /// <summary>
        /// 登录名称
        /// </summary>
        [MaxLength(50,ErrorMessage ="")]
        public string LoginName { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        [MaxLength(50, ErrorMessage = "")]
        public string NickName { get; set; }

        [MaxLength(15,ErrorMessage ="")]
        public string Phone { get; set; }

        [MaxLength(50, ErrorMessage = "")]
        public string Password { get; set; }

        [MaxLength(30, ErrorMessage = "")]
        public string FirstName { get; set; }

        [MaxLength(30, ErrorMessage = "")]
        public string LastName { get; set; }


        [MaxLength(500,ErrorMessage ="")]
        public string Describe { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public EnumSexType Sex { get; set; }

        /// <summary>
        /// 最后一次登录时间
        /// </summary>
        public DateTime LastDate { get; set; }

        /// <summary>
        /// 账户创建时间
        /// </summary>
        public DateTime CDate { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public EnumSysType SysStatus { get; set; }

        /// <summary>
        /// 账户类型
        /// </summary>
        public enum EnumAccountType
        {
            User = 0,   //普通
            Admin = 1   //管理员
        }

        /// <summary>
        /// 删除标记类型
        /// </summary>
        public enum EnumSysType
        {
            正常 = 0,//正常
            删除 = 1     //删除
        }

        /// <summary>
        /// 性别类型
        /// </summary>
        public enum EnumSexType
        {
            Female = 0, //女
            Male = 1    //男
        }
    }
}