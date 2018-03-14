using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class ImageInfo
    {
        [Key]
        public string Id { get; set; }
        
        /// <summary>
        /// 文件名称
        /// </summary>
        [MaxLength(200,ErrorMessage ="")]
        public string FileName { get; set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        [MaxLength(50,ErrorMessage ="")]
        public string FileType { get; set; }

        /// <summary>
        /// 文件相对路径
        /// </summary>
        [MaxLength(500, ErrorMessage = "")]
        public string RelativePath{ get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        [MaxLength(100, ErrorMessage = "")]
        public string AccountId { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        [MaxLength(100,ErrorMessage ="")]
        public string AccountName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CDate { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public EnumType.DelflagType Delflag { get; set; }


    }
}