namespace QLSV_DAL.Model1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SinhVien1
    {
        [Key]
        [StringLength(6)]
        public string MaSV { get; set; }

        [StringLength(40)]
        public string TenSV { get; set; }

        [Required]
        [StringLength(3)]
        public string MaLop { get; set; }

        public DateTime NgaySinh { get; set; }

        public virtual Lop Lop { get; set; }
    }
}
