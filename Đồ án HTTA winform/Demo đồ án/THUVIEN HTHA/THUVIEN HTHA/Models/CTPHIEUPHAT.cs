namespace THUVIEN_HTHA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPHIEUPHAT")]
    public partial class CTPHIEUPHAT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MAPHIEUPHAT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MAMUONSACH { get; set; }

        public int? SOTIENPHAIDONG { get; set; }

        public virtual PHIEUMUONSACH PHIEUMUONSACH { get; set; }

        public virtual PHIEUPHAT PHIEUPHAT { get; set; }
    }
}
