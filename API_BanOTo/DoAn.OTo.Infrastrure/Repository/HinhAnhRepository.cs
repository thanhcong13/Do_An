﻿using Dapper;
using DoAn.OTo.Core.DTO;
using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ubiety.Dns.Core;

namespace DoAn.OTo.Infrastrure.Repository
{
    public class HinhAnhRepository : BaseRepository<HinhAnh>, IHinhAnhRepository
    {
        public async Task<FormatedResponse> GetPage(int page, int pageSize)
        {

            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM HinhAnh LIMIT @PageSize OFFSET @Offset";
                var response =  await SqlConnection.QueryAsync<HinhAnh>(query, new { PageSize = pageSize, Offset = offset });
                var query2 = $"SELECT COUNT(*)  FROM HinhAnh;";
                var response2 = await SqlConnection.ExecuteScalarAsync<int>(query2);
                return new FormatedResponse() { InnerBody = response, Count = response2 };
            }
        }
    }
}
