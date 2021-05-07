using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IReturnsData
    {
        Task DeleteRecord(int ID);
        Task<List<ReturnModel>> GetReturns();

        Task<ReturnModel> GetSingleReturn(int ID);
    }
}