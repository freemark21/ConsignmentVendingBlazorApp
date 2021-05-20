using DataAccessLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public interface IReturnsData
    {
        Task DeleteRecord(int ID);

        Task SaveRecord(ReturnModel returnModel);

        Task<List<ReturnModel>> GetReturns();

        Task<List<ReturnModel>> GetSingleReturn(int ID);
    }
}