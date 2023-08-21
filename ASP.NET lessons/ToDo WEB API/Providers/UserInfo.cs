namespace ToDo_WEB_API.Providers;

public class UserInfo
{
    public string Id { get; }
    public string Username { get; }

    public UserInfo(string id, string username)
    {
        Id = id;
        Username = username;
    }
}
