using RestSharp;

namespace Vehicle.Web.Utility
{
    public interface IRestsharpHelper
    {
        string CallApi(string resource, Method method, bool isHeader = false, string dataBody = null);
    }
}