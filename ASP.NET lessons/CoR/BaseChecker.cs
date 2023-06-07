
abstract class BaseChecker : IChecker
{
    public IChecker Next { get; set; }

    public abstract bool Check(object request);
}
