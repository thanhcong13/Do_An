﻿using DoAn.OTo.Core.DTO;
using DoAn.OTo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Interfaces.Infrastrure
{
    public interface ISanPhamRepository :IBaseRepository<SanPham>
    {
        Task<FormatedResponse> QueryList(int page, int pageSize);
        IEnumerable<SanPham> GetByMaCH(Guid MaCH);
        IEnumerable<SanPham> GetByHang(Guid MaHang);
        Task<FormatedResponse> GetPage(int page, int pageSize);

        Task<FormatedResponse> GetAllCH();
        Task<FormatedResponse> GetAllHang();
        Task<FormatedResponse> GetAllProducts();
        Task<FormatedResponse> GetById (Guid Id);
        Task<FormatedResponse> GetAllProductsByHang(string tenHang);
    }
}
