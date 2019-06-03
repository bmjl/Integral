namespace Integral_MODEL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Integral_Main
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Integral { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Time { get; set; }
    }
}
