
namespace HrLeaveManagementMVC.Services.Base
{
    public class Client : ICient
    {
        public HttpClient httpClient
        {
            get
            {
                return _httpClient;
            }
        }
    }
}
