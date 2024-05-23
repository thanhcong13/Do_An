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

namespace DoAn.OTo.Infrastrure.Repository
{
    public class LaiThuRepository : BaseRepository<LaiThu>, ILaiThuRepository
    {
        public async Task<FormatedResponse> GetPage(int page, int pageSize)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var offset = (page - 1) * pageSize;
                var query = $"SELECT * FROM LaiThu LIMIT @PageSize OFFSET @Offset";
                var response = await SqlConnection.QueryAsync<LaiThu>(query, new { PageSize = pageSize, Offset = offset });

                var query2 = $"SELECT COUNT(*)  FROM LaiThu;";
                var response2 = await SqlConnection.ExecuteScalarAsync<int>(query2);
                return new FormatedResponse() { InnerBody = response, Count = response2 };
            }
        }
        public async Task<IEnumerable<LaiThu>> GetAll()
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var query = $"SELECT * FROM LaiThu";
                return await SqlConnection.QueryAsync<LaiThu>(query);


            }
        }
    }
}
