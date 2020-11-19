using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data;
using Vehicle.Data.Infastractor;

namespace Vehicle.Bussiness.Reposistory
{
    public class BaseReposistory<T> where T : class
    {
        IDbFactory _dbFactory;
        public BaseReposistory(IDbFactory DbFactory)
        {
            _dbFactory = DbFactory;
        }

        public VehicleDBEntities VehicleDB;
        public VehicleDBEntities InitVehicleDB
        {
            get
            {
                return VehicleDB ?? (VehicleDB = _dbFactory.InitVehicleDB);
            }
        }

        public IEnumerable<T> GetTable(Expression<Func<T,bool>> filter = null) //x => x.Id == 5
        {
            //IQueryable<T> : tương tác trực tiếp database trên sql
            IQueryable<T> DbEntity = _dbFactory.InitVehicleDB.Set<T>(); //nguyên table List<Category>
            if(filter != null)
            {
                DbEntity = DbEntity.Where(filter);
            }
            return DbEntity;
        }

        public void Add(T entity)
        {
            _dbFactory.InitVehicleDB.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            var DbEntity = _dbFactory.InitVehicleDB.Entry<T>(entity); //1 dòng dữ liệu Catgory
            DbEntity.State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var DbEntity = _dbFactory.InitVehicleDB.Entry<T>(entity);
            DbEntity.State = System.Data.Entity.EntityState.Deleted;
        }

        public void DeleteById(T entity, int id)
        {
            var DbEntity = _dbFactory.InitVehicleDB.Set<T>();
            var md = DbEntity.Find(id);
            this.Delete(md);
        }

        public void SaveChange()
        {
            _dbFactory.InitVehicleDB.SaveChanges();
        }
    }
}
