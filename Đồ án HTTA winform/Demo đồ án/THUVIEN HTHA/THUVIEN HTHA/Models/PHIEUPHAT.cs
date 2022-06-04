namespace THUVIEN_HTHA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHIEUPHAT")]
    public partial class PHIEUPHAT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PHIEUPHAT()
        {
            CTPHIEUPHATs = new HashSet<CTPHIEUPHAT>();
        }

        [Key]
        [StringLength(5)]
        public string MAPHIEUPHAT { get; set; }

        [Column(TypeName = "date")]
        public DateTime NGAYPHAT { get; set; }

        [Required]
        [StringLength(50)]
        public string LYDOPHAT { get; set; }

        [StringLength(50)]
        public string HINHTHUCPHAT { get; set; }

        [Required]
        [StringLength(5)]
        public string MADOCGIA { get; set; }

        [Required]
        [StringLength(5)]
        public string MANHANVIEN { get; set; }

        [Required]
        [StringLength(5)]
        public string MASACH { get; set; }

        [Required]
        [StringLength(5)]
        public string MAMUONSACH { get; set; }

        public virtual DOCGIA DOCGIA { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual PHIEUMUONSACH PHIEUMUONSACH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUPHAT> CTPHIEUPHATs { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
