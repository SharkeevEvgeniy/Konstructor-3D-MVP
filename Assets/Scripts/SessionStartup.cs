using UnityEngine;
using System;

public class SessionStartup : MonoBehaviour
{
    [SerializeField] private AuthorizationView _authorizationView;
    private AuthorizationPresenter _authorizationPresenter;

    [SerializeField] private ProjectView _projectView;

    public SessionInfo SessionInfo { get; private set; }

    private void Awake()
    {
        AuthorizationModel authorizationModel = new AuthorizationModel();
        _authorizationPresenter = new AuthorizationPresenter(_authorizationView, authorizationModel);
        _authorizationView.SetPresenter(_authorizationPresenter);
        _authorizationView.Initialize();

        ProjectModel projectModel = new ProjectModel();
        ProjectPresenter projectPresenter = new ProjectPresenter(projectModel, _projectView);
        _projectView.SetPresenter(projectPresenter);
    }

    private void OnEnable()
    {
        _authorizationPresenter.OnSuccessLoginnedEvent += InitSession;
    }

    private void OnDisable()
    {
        _authorizationPresenter.OnSuccessLoginnedEvent -= InitSession;
    }

    private void InitSession(string companyName)
    {
        SessionInfo = new SessionInfoBuilder()
            .IsLoginned(true)
            .SetCompanyName(companyName)
            .SetStartTime($"{DateTime.Now.Minute}:{DateTime.Now.Hour}")
            .SetStartDate($"{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}")
            .Build();
    }
}
