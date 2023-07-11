namespace CleanArchitecture.Common.Dates;

public sealed class DateService : IDateService
{
    public DateTime GetDate() => DateTime.Now.Date;
}
