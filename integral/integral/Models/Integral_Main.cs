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
        [DisplayName("��Ա���")]
        public int Num { get; set; }

        [Required]
        [StringLength(10)]
        [DisplayName("����")]
        public string Name { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("����")]
        public decimal Integral { get; set; }
        [DisplayName("���ӵĻ���")]
        [NotMapped]
        public decimal Integral_NM { get; set; }
    }
}
