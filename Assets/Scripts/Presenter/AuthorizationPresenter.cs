using System;

public class AuthorizationPresenter
{
    private AuthorizationView _authorizationView;
    private AuthorizationModel _authorizationModel;

    public event Action<string> OnSuccessLoginnedEvent;

    public AuthorizationPresenter(AuthorizationView view, AuthorizationModel model)
    {
        _authorizationModel = model;
        _authorizationView = view;
    }

    public void TryToLogin(string login, string password)
    {
        RefreshData(login, password);
        RoutinesStarter.Instance.TryToLogin(_authorizationModel, _authorizationView, OnSuccessLoginnedEvent);
    }

    private void RefreshData(string login, string password)
    {
        _authorizationModel.Login = login;
        _authorizationModel.Password = password;
    }
}
