namespace FindJobWebApi.Services
{
    public interface ITokenService
    {
        public string generateToken(int id, string role);
    }
}
