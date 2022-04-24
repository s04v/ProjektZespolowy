using FindJobWebApi.DTOs;

namespace FindJobWebApi.Services
{
    public interface IUserService
    {
        public string SignIn(LoginUserDTO userDTO);

        public string SignUp(CreateUserDTO userDTO);

        public UserDTO GetUser(int id);

        public string AddProfile(int id, ModifyUserDTO dto);
    }
}
