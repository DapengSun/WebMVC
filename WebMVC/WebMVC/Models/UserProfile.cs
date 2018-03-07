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
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int _id { get; set; }

        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 账户角色ID
        /// </summary>
        [MaxLength(50,ErrorMessage ="")]
        public string RoleId { get; set; }

        /// <summary>
        /// 账户角色名称
        /// </summary>
        [MaxLength(100,ErrorMessage ="")]
        public string RoleName { get; set; }

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

        /// <summary>
        /// 手机号码
        /// </summary>
        [MaxLength(15,ErrorMessage ="")]
        public string Phone { get; set; }
        
        /// <summary>
        /// 账号密码
        /// </summary>
        [MaxLength(50, ErrorMessage = "")]
        public string Password { get; set; }


        /// <summary>
        /// 姓名 - 姓
        /// </summary>
        [MaxLength(30, ErrorMessage = "")]
        public string FirstName { get; set; }

        /// <summary>
        /// 姓名 - 名
        /// </summary>
        [MaxLength(30, ErrorMessage = "")]
        public string LastName { get; set; }

        /// <summary>
        /// 企业名称
        /// </summary>
        [MaxLength(100,ErrorMessage ="")]
        public string Company { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        [MaxLength(100, ErrorMessage = "")]
        public string City { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [MaxLength(100, ErrorMessage = "")]
        public string Country { get; set; }

        /// <summary>
        /// 邮编号码
        /// </summary>
        [MaxLength(50,ErrorMessage ="")]
        public string PostalCode{get;set;}

        /// <summary>
        /// 个性签名
        /// </summary>
        [MaxLength(500, ErrorMessage = "")]
        public string PersonalitySignature{get;set;}

        /// <summary>
        /// Email
        /// </summary>
        [MaxLength(100,ErrorMessage ="")]
        public string Email { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        [MaxLength(200,ErrorMessage ="")]
        public string Address { get; set; }

        /// <summary>
        /// 个人描述
        /// </summary>
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