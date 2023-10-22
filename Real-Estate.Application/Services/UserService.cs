using AutoMapper;
using Real_Estate.Application.DTOs.Account;
using Real_Estate.Application.Enums;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Application.ViewModels.Admin;
using Real_Estate.Application.ViewModels.Users;


namespace Real_Estate.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public UserService(IAccountService accountService, IMapper mapper)
        {
            _accountService = accountService;
            _mapper = mapper;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginViewModel vm)
        {
            AuthenticationRequest loginRequest = _mapper.Map<AuthenticationRequest>(vm);
            AuthenticationResponse userResponse = await _accountService.AuthenticateAsync(loginRequest);
            return userResponse;
        }

        public async Task SignOutAsync()
        {
            await _accountService.SignOutAsync();
        }

        public async Task<RegisterResponse> RegisterAsync(SaveUserViewModel vm, string origin, Roles typeOfUser)
        {
            RegisterRequest registerRequest = _mapper.Map<RegisterRequest>(vm);
            return await _accountService.RegisterUserAsync(registerRequest, origin, typeOfUser);
        }

        public async Task<string> ConfirmEmailAsync(string userId, string token)
        {
            return await _accountService.ConfirmAccountAsync(userId, token);
        }

        public async Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPasswordViewModel vm, string origin)
        {
            ForgotPasswordRequest forgotRquest = _mapper.Map<ForgotPasswordRequest>(vm);
            return await _accountService.ForgotPasswordAsync(forgotRquest, origin);
        }

        public async Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordViewModel vm)
        {
            ResetPasswordRequest resetRequest = _mapper.Map<ResetPasswordRequest>(vm);
            return await _accountService.ResetPasswordAsync(resetRequest);

        }

        public async Task<HomeAdminViewModel> GetUsersQuantity()
        {
            return await _accountService.GetUsersQuantity();
        }

        public async Task<List<UserViewModel>> GetAllUsersViewModels()
        {
            return await _accountService.GetAllUserViewModels();
        }

        public async Task<UpdateUserViewModel> GetUserSaveViewModelByUsername(string username)
        {
            List<UserViewModel> userViewModelsList = await _accountService.GetAllUserViewModels();

            return _mapper.Map<List<UpdateUserViewModel>>(userViewModelsList).Where(user => user.UserName == username).FirstOrDefault();
        }

        public async Task<UpdateAgentUserResponse> Update(UpdateUserViewModel vm)
        {
            return await _accountService.UpdateUserAsync(vm);
        }

    }
}
