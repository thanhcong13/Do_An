﻿using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class NhanVien
    {
        [PrimaryKey]
        public string MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }
        public string ChucVu { get; set; }
        public Guid? MaCH { get; set; }
        public string? TenCH { get; set; }
        public DateTime? Created_at { get; set; } = DateTime.Now;


    }
}
