
using MyToDo.Shared.Dtos;
namespace MyToDo.api.Service
{
    public interface ILoginService
    {

        Task<ApiResponse>  LoginAsync(string Account, string Password);
        Task<ApiResponse> Register(UserDto userDto);
    }
}
