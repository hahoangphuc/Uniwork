using Vehicle.Data;

namespace Vehicle.Bussiness.Reposistory
{
    public interface IAccountReposistory
    {
        User CheckLogin(string username, string password);
    }
}