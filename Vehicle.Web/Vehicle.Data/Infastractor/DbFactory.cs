using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Data.Infastractor
{
    public class DbFactory : Disposable, IDbFactory
    {
        public VehicleDBEntities VehicleDB; //field
        public VehicleDBEntities InitVehicleDB //property
        {
            get
            {
                return VehicleDB ?? (VehicleDB = new VehicleDBEntities());
            }
        }

        protected override void DisposeCore() //method
        {
            if(VehicleDB != null)
            {
                VehicleDB.Dispose();
            }
        }
    }
}
