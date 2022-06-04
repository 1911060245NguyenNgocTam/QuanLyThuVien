namespace THUVIEN_HTHA.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            PHIEUMUONSACHes = new HashSet<PHIEUMUONSACH>();
            PHIEUPHATs = new HashSet<PHIEUPHAT>();
        }

        [Key]
        [StringLength(5)]
        public string MANHANVIEN { get; set; }

        [StringLength(30)]
        public string HOTENNHANVIEN { get; set; }

        [Required]
        [StringLength(11)]
        public string SDTNHANVIEN { get; set; }

        [Required]
        [StringLength(70)]
        public string DIACHI { get; set; }

        [Required]
        [StringLength(5)]
        public string PHAI { get; set; }

        [Required]
        [StringLength(20)]
        public string CHUCVU { get; set; }

        public int ID { get; set; }

        public virtual DANGNHAP DANGNHAP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUMUONSACH> PHIEUMUONSACHes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUPHAT> PHIEUPHATs { get; set; }
    }
}
