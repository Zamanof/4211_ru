
interface IChecker
{
    public IChecker Next { get; set; }
    public bool Check(object request);
}
