namespace AuthserverAPi.data{
    public interface ILoginRepository
    {
        bool UserLogin(string Username, string Password, out string role);
    }
}