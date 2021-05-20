using Dapper;
using DataAccessLibrary.Models;
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
            return _db.SaveData(sql, new { ID });
        }

        public Task<List<ReturnModel>> GetSingleReturn(int ID)
        {
            string sql = "spConsignmentReturns_GetSingleRecord @ID";
            return _db.LoadData<ReturnModel, dynamic>(sql, new { ID });
        }

        public Task SaveRecord(ReturnModel item)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ID", item.ID);
            parameters.Add("@Qty", item.Qty);
            string sql = "spConsignmentReturns_SaveRecord";
            return _db.SaveData(sql, parameters);
        }
    }
}
