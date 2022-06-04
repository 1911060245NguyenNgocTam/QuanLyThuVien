namespace THUVIEN_HTHA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            PHIEUPHATs = new HashSet<PHIEUPHAT>();
            CTPHIEUMUONSACHes = new HashSet<CTPHIEUMUONSACH>();
        }

        [Key]
        [StringLength(5)]
        public string MASACH { get; set; }

        [Required]
        [StringLength(70)]
        public string TENSACH { get; set; }

        [Column(TypeName = "date")]
        public DateTime NAMXUATBAN { get; set; }

        public int SOLUONG { get; set; }

        [Required]
        [StringLength(5)]
        public string MANHAXUATBAN { get; set; }

        [Required]
        [StringLength(5)]
        public string MATHELOAI { get; set; }

        public int SOTRANG { get; set; }

        [Required]
        [StringLength(5)]
        public string MATACGIA { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUPHAT> PHIEUPHATs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTPHIEUMUONSACH> CTPHIEUMUONSACHes { get; set; }

        public virtual TACGIA TACGIA { get; set; }

        public virtual THELOAI THELOAI { get; set; }
    }
}
