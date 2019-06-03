namespace integral.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Integral_History
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("人员编号")]
        public int Main_Num { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("积分")]
        public decimal Integral { get; set; }

        [Column(TypeName = "datetime")]
        [DisplayName("添加日期")]
        public DateTime Time { get; set; }
    }
}
