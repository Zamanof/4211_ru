
class Human
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }

    public Human(string userName, string password, string email)
    {
        UserName = userName;
        Password = password;
        Email = email;
    }
}
