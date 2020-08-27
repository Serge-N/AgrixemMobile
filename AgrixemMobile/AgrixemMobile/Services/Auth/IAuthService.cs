using AgrixemMobile.Models;
using System.Threading.Tasks;

namespace AgrixemMobile.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}
