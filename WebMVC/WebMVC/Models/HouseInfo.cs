namespace WebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("spiderdb.houseinfo")]
    public partial class houseinfo
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string HouseTitle { get; set; }

        [StringLength(100)]
        public string HouseName { get; set; }

        [StringLength(50)]
        public string HousePattern { get; set; }

        [StringLength(50)]
        public string HouseRange { get; set; }

        [StringLength(50)]
        public string HouseFace { get; set; }

        [StringLength(50)]
        public string HouseStyle { get; set; }

        [StringLength(30)]
        public string IsElevator { get; set; }

        [StringLength(150)]
        public string HousePosition { get; set; }

        [StringLength(150)]
        public string HouseArea { get; set; }

        [StringLength(50)]
        public string HouseLike { get; set; }

        [StringLength(50)]
        public string HouseLook { get; set; }

        [StringLength(50)]
        public string HouseReleaseDate { get; set; }

        [StringLength(150)]
        public string traffic { get; set; }

        [StringLength(50)]
        public string taxfree { get; set; }

        [StringLength(50)]
        public string haskey { get; set; }

        [StringLength(50)]
        public string HouseTotalPrice { get; set; }

        [StringLength(50)]
        public string HousePrice { get; set; }

        public DateTime? CDate { get; set; }

        public int? Delflag { get; set; }

        [StringLength(20)]
        public string TotalPriceUnit { get; set; }

        [StringLength(20)]
        public string PriceUnit { get; set; }

        public float? HouseRangeNum { get; set; }

        public int? HouseLikeNum { get; set; }

        public int? HouseLookNum { get; set; }
    }
}
