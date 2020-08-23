using Intranet.Common.Models;
using System.Threading.Tasks;

namespace Intranet.Common.Services
{
    public interface IApiService
    {
        Task<bool> CheckConnectionAsync(string url);
        Task<Response<ManagerResponse>> GetEmployeByEmailAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);
        Task<Response<TokenResponse>> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);
       
        
    }
}