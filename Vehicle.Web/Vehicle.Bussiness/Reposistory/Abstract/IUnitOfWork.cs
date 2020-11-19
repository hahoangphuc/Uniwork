namespace Vehicle.Bussiness.Reposistory
{
    public interface IUnitOfWork
    {
        ICategoryReposistory CategoryReposistory { get; }
        ICustomerReposistory customerReposistory { get; }
    }
}