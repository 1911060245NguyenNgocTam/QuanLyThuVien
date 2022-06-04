namespace THUVIEN_HTHA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPHIEUMUONSACH")]
    public partial class CTPHIEUMUONSACH
    {
        [Key]
        [Column(Order = 0, TypeName = "date")]
        public DateTime NGAYTRA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MASACH { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string MAMUONSACH { get; set; }

        public virtual PHIEUMUONSACH PHIEUMUONSACH { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
