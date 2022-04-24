using FindJobWebApi.DTOs;

namespace FindJobWebApi.Services
{
    public interface IUserService
    {
        public string SignIn(LoginUserDTO userDTO);

        public string SignUp(CreateUserDTO userDTO);

        public UserDTO GetUser(ulong id);

        public string AddProfile(ulong id, ModifyUserDTO dto);
    }
}
