namespace Vehicle.Data.Infastractor
{
    public interface IDbFactory
    {
        VehicleDBEntities InitVehicleDB { get; }
    }
}