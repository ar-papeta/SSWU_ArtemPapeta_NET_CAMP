namespace MoviesStore.Auth.Authentication
{
    public interface ITokenFactory
    {
        public string CreateAccessToken(string userId, string userRole);
    }
}
