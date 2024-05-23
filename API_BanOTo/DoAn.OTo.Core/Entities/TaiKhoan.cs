﻿using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class TaiKhoan
    {
        [PrimaryKey]        
        public string TenTaiKhoan { get; set; }
        [NotEmpty]
        [ProppertyName("Mật khẩu")]
        public string MatKhau { get; set; }
        [ProppertyName("Mã nhân viên")]
        public string? MaNV { get; set; }
        public string? TenNV { get; set; }
        [ProppertyName("Mã group")]
        public string? GID { get; set; }


    }
}
