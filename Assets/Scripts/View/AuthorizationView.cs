using UnityEngine;
using TMPro;
using System;

public class AuthorizationView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _loginInputField;
    [SerializeField] private TMP_InputField _passwordInputField;
    [SerializeField] private TMP_Text _companyName;

    [SerializeField] private GameObject _authorizationPanel;

    private AuthorizationPresenter _presenter;

    public void SetPresenter(AuthorizationPresenter presenter) => _presenter = presenter;

    public void Initialize()
    {
        _presenter.OnSuccessLoginnedEvent += SetCompanyName;
    }

    private void OnDisable()
    {
        _presenter.OnSuccessLoginnedEvent -= SetCompanyName;
    }

    private void SetCompanyName(string companyName) => _companyName.text = companyName;

    public void DisablePanel() => _authorizationPanel.SetActive(false);

    public string GetLogin() => _loginInputField.text;

    public string GetPassword() => _passwordInputField.text;

    public void OpenRegistrationSiteOnClick()
    {
        try
        {
            Application.OpenURL("http://h100516.hostru07.fornex.host/diplomkonstructor3d.com/index.php");
        }
        catch(Exception e)
        {
            Debug.LogError(e);
        }
    }

    public void TryToLoginOnClick()
    {
        string login = _loginInputField.text;
        string password = _passwordInputField.text;
        _presenter.TryToLogin(login, password);
    }
}
