﻿using DoAn.OTo.Core.BuidAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Entities
{
    public class LaiThu
    {
        [PrimaryKey]
        public Guid MaLT { get; set; }
        public string TenKH { get; set; }
        public string EmailKH { get; set; }
        public string SDTKH { get; set; }
        public Guid? MaSP { get; set; }
        public string? TenSP { get; set; }
        public DateTime NgayLT { get; set; }
    }
}
