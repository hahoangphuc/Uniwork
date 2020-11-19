using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data.Infastractor;

namespace Vehicle.Bussiness.Reposistory
{
    public class UnitOfWork : IUnitOfWork
    {
        IDbFactory _DbFactory;
        ICategoryReposistory _categoryReposistory;
        ICustomerReposistory _customerReposistory;
        public UnitOfWork(IDbFactory DbFactory, ICategoryReposistory categoryReposistory, ICustomerReposistory customerReposistory)
        {
            _DbFactory = DbFactory;
            _categoryReposistory = categoryReposistory;
            _customerReposistory = customerReposistory;
        }

        public ICategoryReposistory CategoryReposistory
        {
            get
            {
                return _categoryReposistory ?? (_categoryReposistory = new CategoryReposistory(_DbFactory));
            }
        }

        public ICustomerReposistory customerReposistory
        {
            get
            {
                return _customerReposistory ?? (_customerReposistory = new CustomerReposistory(_DbFactory));
            }
        }
    }
}
