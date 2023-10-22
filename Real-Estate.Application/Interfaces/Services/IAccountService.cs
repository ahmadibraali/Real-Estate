using Real_Estate.Application.DTOs.Account;
using Real_Estate.Application.DTOs.Properties;
using Real_Estate.Application.Enums;
using Real_Estate.Application.ViewModels.Admin;
using Real_Estate.Application.ViewModels.Agents;
using Real_Estate.Application.ViewModels.Users;

namespace Real_Estate.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<bool> ChangesStatusUser(string id, bool status);
        Task<List<AgentsViewModel>> GetAllUsers();
        Task<List<AgentsViewModel>> GetAllAgents();
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegisterResponse> RegisterUserAsync(RegisterRequest request, string origin, Roles tyoeOfUser);
        Task SignOutAsync();
        Task<string> ConfirmAccountAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordRequest request, string origin);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);

        Task<UpdateAgentUserResponse> UpdateAgentUserByUserNameAsync(UpdateAgentUserRequest request);
        Task<UpdateAgentUserResponse> GetAgentUserByUserNameAsync(string userName);
        Task<HomeAdminViewModel> GetUsersQuantity();
        Task<List<UserViewModel>> GetAllUserViewModels();
        Task<UpdateAgentUserResponse> UpdateUserAsync(UpdateUserViewModel request);
        Task<ChangeUserStatusResponse> ChageUserStatusAsync(string id);
        Task<ChangeUserStatusResponse> DeleteUserAsync(string id);
        Task<AgentProperty> GetAgentPropertyByIdAsync(string id);

    }
}
