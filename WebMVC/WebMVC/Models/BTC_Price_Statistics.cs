using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMVC.Models
{
    public class BTC_Price_Statistics
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int _Id { get; set; }
        [Key]
        public string Id { get; set; }
        public float? LastPriceUSD { get; set; }
        public float? DailyChange { get; set; }
        public float? DailyChangePercent { get; set; }
        public float? DaysLow { get; set; }
        public float? DaysHigh { get; set; }
        public float? DaysOpen { get; set; }
        public int? DaysVolume { get; set; }
        public DateTime CDate { get; set; }
    }
}