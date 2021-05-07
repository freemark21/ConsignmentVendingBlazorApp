﻿using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class ReturnsData : IReturnsData
    {
        private readonly ISqlDataAccess _db;

        public ReturnsData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<ReturnModel>> GetReturns()
        {
            string sql = "spConsignmentReturns_GetRecords";
            return _db.LoadData<ReturnModel, dynamic>(sql, new { });
        }

        public Task DeleteRecord(int ID)
        {
            string sql = "spConsignmentReturns_DeleteRecord @ID";
            return _db.SaveData(sql, ID);
        }

        public Task<ReturnModel> GetSingleReturn(int ID)
        {
            string sql = "spConsignmentReturns_GetSingleReturn @ID";
            return _db.LoadSingle<ReturnModel, dynamic>(sql, ID);
        }
    }
}
