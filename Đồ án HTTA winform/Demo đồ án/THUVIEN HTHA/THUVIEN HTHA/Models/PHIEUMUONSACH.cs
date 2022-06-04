namespace THUVIEN_HTHA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUMUONSACH")]
    public partial class PHIEUMUONSACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUMUONSACH()
        {
            CTPHIEUMUONSACHes = new HashSet<CTPHIEUMUONSACH>();
            CTPHIEUPHATs = new HashSet<CTPHIEUPHAT>();
            PHIEUPHATs = new HashSet<PHIEUPHAT>();
        }

        [Key]
        [StringLength(5)]
        public string MAMUONSACH { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYCAP { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYMUON { get; set; }

        [Required]
        [StringLength(5)]
        public string MADOCGIA { get; set; }

        [Required]
        [StringLength(5)]
        public string MANHANVIEN { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUMUONSACH> CTPHIEUMUONSACHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUPHAT> CTPHIEUPHATs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUPHAT> PHIEUPHATs { get; set; }
    }
}
