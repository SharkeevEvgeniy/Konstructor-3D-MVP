public class AuthorizationModel
{
    private string _login;
    private string _password;

    public string Login
    {
        get
        {
            return _login;
        }
        set
        {
            _login = value;
        }
    }

    public string Password
    {
        get
        {
            return _password;
        }
        set
        {
            _password = value;
        }
    }
}
