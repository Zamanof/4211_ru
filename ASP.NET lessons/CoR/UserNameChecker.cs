
class UserNameChecker : BaseChecker
{
    public override bool Check(object request)
    {
        if (request is Human human)
        {
            if (!string.IsNullOrWhiteSpace(human.UserName))
            {
                return Next.Check(request);
            }
        }
        return false;
    }
}
