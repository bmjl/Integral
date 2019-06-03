namespace integral.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Integral_Main
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("人员编号")]
        public int Num { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("姓名")]
        public string Name { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("积分")]
        public decimal Integral { get; set; }
        [DisplayName("增加的积分")]
        [NotMapped]
        public decimal Integral_NM { get; set; }
    }
}
