using CleanArchitecture.Application.Interfaces;

namespace CleanArchitecture.Application.Customers.Queries.GetCustomerList;

public sealed class GetCustomersListQuery
    : IGetCustomersListQuery
{
    private readonly IDatabaseService _database;

    public GetCustomersListQuery(IDatabaseService database) => _database = database;

    public List<CustomerModel> Execute()
    {
        IQueryable<CustomerModel> customers = _database.Customers
                                                       .Select(p => new CustomerModel
                                                       {
                                                           Id   = p.Id,
                                                           Name = p.Name
                                                       });

        return customers.ToList();
    }
}
