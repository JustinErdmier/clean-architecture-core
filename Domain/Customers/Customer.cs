using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Customers;

public sealed class Customer : IEntity
{
    public string Name { get; set; }

    public int Id { get; set; }
}
