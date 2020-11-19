using System.Collections.Generic;
using Vehicle.Data;

namespace Vehicle.Bussiness.Reposistory
{
    public interface ICustomerReposistory
    {
        List<sp_GetAllListCustomer_Result> GetAllList(int Page, int PageSize, ref int TotalR);
        bool CreateUpdate(Customer obj);
    }
}