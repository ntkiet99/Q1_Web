using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyDatNen.Models
{
    public class Nen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string TenNen { get; set; }
        public string DienTich { get; set; }
        public float GiaTri { get; set; }
        public int TinhTrang { get; set; }
        public string DiaChi { get; set; }
        public string GhiChu { get; set; }
        public string HoTen { get; set; }
        public string CMND { get; set; }
        public DateTime NgayKy { get; set; } = DateTime.Now;
        public string SDT { get; set; }
    }
}