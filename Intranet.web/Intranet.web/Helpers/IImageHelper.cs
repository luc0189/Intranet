using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Intranet.web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile);
        Task<string> UploadFotoAsync(IFormFile imageFile);
    }
}
