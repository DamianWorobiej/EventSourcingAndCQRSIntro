namespace Common.Helpers;

public class DateTimeHelper : IDateTimeHelper
{
    public DateTime GetUtcNow() => DateTime.UtcNow;
}
