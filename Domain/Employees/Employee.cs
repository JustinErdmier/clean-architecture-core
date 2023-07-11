using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Employees;

public sealed class Employee : IEntity
{
    public string Name { get; set; }

    public int Id { get; set; }
}
