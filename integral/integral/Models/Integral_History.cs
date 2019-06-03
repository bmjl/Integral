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
        [DisplayName("��Ա���")]
        public int Main_Num { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("����")]
        public decimal Integral { get; set; }

        [Column(TypeName = "datetime")]
        [DisplayName("�������")]
        public DateTime Time { get; set; }
    }
}
