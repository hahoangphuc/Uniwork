using System.Collections.Generic;
using Vehicle.Bussiness.Models;
using Vehicle.Data;

namespace Vehicle.Bussiness.Reposistory
{
    public interface ICategoryReposistory
    {
        List<sp_GetAllListCategory_Result> GetAllList(int Page, int Pagesize, ref int TotalRow);
        List<DropdownlistModel> GetDropDownListData();
        bool CreateUpdate(Category obj);
    }
}