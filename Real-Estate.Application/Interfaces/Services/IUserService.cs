using Real_Estate.Application.DTOs.Account;
using Real_Estate.Application.Enums;
using Real_Estate.Application.ViewModels.Admin;
using Real_Estate.Application.ViewModels.Users;

namespace Real_Estate.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthenticationResponse> LoginAsync(LoginViewModel vm);
        Task SignOutAsync();
        Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin, Roles typeOfUser);
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm);
        Task<HomeAdminViewModel> GetUsersQuantity();
        Task<List<UserViewModel>> GetAllUsersViewModels();
        Task<UpdateUserViewModel> GetUserSaveViewModelByUsername(string username);
        Task<UpdateAgentUserResponse> Update(UpdateUserViewModel vm);
    }
}
