using AminesStream.Models.Auth;

namespace AminesStream.Repositories.Abstractions
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);

        Task LogoutAsync();


        Task<Status> RegisterAsync(RegistrationModel model);
    }
}
