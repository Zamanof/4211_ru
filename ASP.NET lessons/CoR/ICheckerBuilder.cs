
interface ICheckerBuilder
{
    public BaseChecker EmailChecker { get; set; }
    public BaseChecker UserNameChecker { get; set; }
    public BaseChecker PasswordChecker { get; set; }
}
