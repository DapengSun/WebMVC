using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static WebMVC.Models.EnumType;

namespace WebMVC.Models
{
    [Table("BlogsInfo")]
    public class BlogsInfo
    {
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [MaxLength(200,ErrorMessage ="")]
        public string BlogHeading { get; set; }

        /// <summary>
        /// 副标题
        /// </summary>
        [MaxLength(200, ErrorMessage = "")]
        public string BlogSubHeading { get; set; }

        /// <summary>
        /// 作者ID
        /// </summary>
        [MaxLength(200, ErrorMessage = "")]
        public string BlogAuthorId { get; set; }

        /// <summary>
        /// 作者ID
        /// </summary>
        [MaxLength(200, ErrorMessage = "")]
        public string BlogAuthorName { get; set; }

        /// <summary>
        /// 封面图
        /// </summary>
        [MaxLength(200, ErrorMessage = "")]
        public string BlogsSurfacePlot { get; set; }

        /// <summary>
        /// 文章简介
        /// </summary>
        [MaxLength(1000,ErrorMessage = "")]
        public string BlogAbstarct { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string BlogContent { get; set; }

        /// <summary>
        /// 文章点赞数
        /// </summary>
        public int LikeNum { get; set; }

        /// <summary>
        /// 文章评论数
        /// </summary>
        public int CommentNum { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public DelflagType Delflag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CDate { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UDate { get; set; }
    }
}