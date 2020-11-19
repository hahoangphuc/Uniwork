using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Bussiness.Models;
using Vehicle.Data;
using Vehicle.Data.Infastractor;

namespace Vehicle.Bussiness.Reposistory
{
    public class CategoryReposistory : BaseReposistory<Category>, ICategoryReposistory
    {
        public CategoryReposistory(IDbFactory DbFactory) : base(DbFactory)
        {
        }

        public List<sp_GetAllListCategory_Result> GetAllList(int Page, int Pagesize, ref int TotalRow)
        {
            var TotalR = new ObjectParameter("TotalRow", typeof(int));
            var lsData = InitVehicleDB.sp_GetAllListCategory(Page, Pagesize, TotalR).ToList();
            TotalRow = (int)TotalR.Value;
            return lsData;
        }

        public bool CreateUpdate(Category obj)
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

        public List<DropdownlistModel> GetDropDownListData()
        {
            //Select() : get dữ liệu trong các field
            return base.GetTable().Select(x => new DropdownlistModel() {
                                             Value = x.Id.ToString(),
                                             Text = x.kindOfName
                                        }).ToList();



            //base.InitVehicleDB.Categories.Where(x => x.kindOfName.Contains("Toyota")).FirstOrDefault();
            //db.Categories.Where(x => x.Id == 5).FirstOrDefault();
        }
    }
}
