using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class ProductInfo
    {
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// 产品编码
        /// </summary>
        [MaxLength(100,ErrorMessage ="")]
        public string ProductNum { get; set; }

        /// <summary>
        /// 产品名称
        /// </summary>
        [MaxLength(150, ErrorMessage = "")]
        public string ProductName { get; set; }

        /// <summary>
        /// 库存数据
        /// </summary>
        [ConcurrencyCheck]
        public int StoreNum { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public EnumType.DelflagType Delflag { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CDate { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        [MaxLength(50, ErrorMessage = "")]
        public string AccountId { get; set; }

        /// <summary>
        /// 创建人姓名
        /// </summary>
        [MaxLength(100, ErrorMessage = "")]
        public string AccountName { get; set; }
    }
}