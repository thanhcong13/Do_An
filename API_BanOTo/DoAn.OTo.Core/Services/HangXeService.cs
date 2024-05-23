﻿using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAn.OTo.Core.Services
{
    public class HangXeService : BaseService<HangXe> , IHangXeService
    {
        IHangXeRepository _hangXeRepository;
        public HangXeService(IHangXeRepository hangXeRepository):base(hangXeRepository)
        {
            _hangXeRepository = hangXeRepository;
        }
    }
}
