
class EmailChecker : BaseChecker
{
    public override bool Check(object request)
    {
        if (request is Human human)
        {
            return !string.IsNullOrEmpty(human.Email) && human.Email.Contains("@");
        }
        return false;
    }
}
