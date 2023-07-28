using GrindRailsAPI.Shared.DTOs;
using GrindRailsAPI.Shared.DTOs.User;
using GrindRailsAPI.Shared.ModelsView.User;

namespace GrindRailsAPI.Services.Interfaces
{
    public interface IIdentityServices
    {
        Task<ServiceResponseDTO<UserViewModel>> CreateUser(UserCreateViewModel userCreateViewModel);

        Task<UserLoginResponse> Login(UserLoginViewModel userLogin);

        Task<UserLoginResponse> LoginNoPassword(string userId);
    }
}
