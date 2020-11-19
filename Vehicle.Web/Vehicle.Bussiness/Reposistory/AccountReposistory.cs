using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data;
using Vehicle.Data.Infastractor;

namespace Vehicle.Bussiness.Reposistory
{
    public class AccountReposistory : BaseReposistory<User>, IAccountReposistory
    {
        public AccountReposistory(IDbFactory DbFactory) : base(DbFactory)
        {
        }

        public User CheckLogin (string username, string password)
        {
            var res = InitVehicleDB.Users.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();
            return res;
        }
    }
}
