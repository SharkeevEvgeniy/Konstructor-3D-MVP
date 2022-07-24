public class SessionInfoBuilder
{
    private SessionInfo _sessionInfo;

    public SessionInfoBuilder SetStartTime(string value)
    {
        _sessionInfo.SessionStartTime = value;
        return this;
    }

    public SessionInfoBuilder SetStartDate(string value)
    {
        _sessionInfo.SessionStartDate = value;
        return this;
    }

    public SessionInfoBuilder SetCompanyName(string value)
    {
        _sessionInfo.CompanyName = value;
        return this;
    }

    public SessionInfoBuilder IsLoginned(bool value)
    {
        _sessionInfo.IsLogined = value;
        return this;
    }

    public SessionInfo Build()
    {
        return _sessionInfo;
    }
}
