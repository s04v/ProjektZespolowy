using AutoMapper;
using FindJobWebApi.DataBase;
using FindJobWebApi.DTOs;
using FindJobWebApi.Models;
using FindJobWebApi.Secure;

namespace FindJobWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public UserService(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public string SignIn(LoginUserDTO userDTO)
        {
           var currentUser = _context.Users.SingleOrDefault(x => x.Email.Equals(userDTO.Email));
           var hashedPassword = userDTO.Password.getHash();
            if (currentUser == null || !hashedPassword.Equals(currentUser.Password))
            {
                return "Login/Password is incorrect!";
            }
            return currentUser.Id.ToString();
        }

        public string SignUp(CreateUserDTO userDTO)
        {
            if (_context.Users.Any(x => x.Email == userDTO.Email))
            {
                return "Account with this email address already exists!";
            }

            var currentUser = _mapper.Map<User>(userDTO);
            currentUser.Password = userDTO.Password.getHash();
            _context.Users.Add(currentUser);
            _context.SaveChanges();
            return "OK";
        }
    }
}
