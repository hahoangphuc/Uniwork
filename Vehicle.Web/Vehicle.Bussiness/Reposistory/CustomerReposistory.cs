using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data;
using Vehicle.Data.Infastractor;

namespace Vehicle.Bussiness.Reposistory
{
    public class CustomerReposistory : BaseReposistory<Customer>, ICustomerReposistory
    {
        public CustomerReposistory(IDbFactory DbFactory) : base(DbFactory)
        {
        }

        public List<sp_GetAllListCustomer_Result> GetAllList(int Page,int PageSize,ref int TotalR)
        {
            var TotalRow = new ObjectParameter("TotalRow",typeof(int));
            var ls = base.InitVehicleDB.sp_GetAllListCustomer(Page, PageSize, TotalRow).ToList();
            TotalR = (int)TotalRow.Value;
            return ls;
        }

        public bool CreateUpdate(Customer obj)
        {
            try
            {
                if(obj.Id == 0)
                {
                    obj.IsActive = true;
                    base.Add(obj);
                }
                else
                {
                    base.Update(obj);
                }
                base.SaveChange();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
            
        }
    }
}
