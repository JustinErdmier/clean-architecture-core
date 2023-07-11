using CleanArchitecture.Application.Employees.Queries.GetEmployeesList;

using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using AppContext = CleanArchitecture.Specification.Shared.AppContext;

namespace CleanArchitecture.Specification.Employees.GetEmployeesList;

[ Binding ]
public sealed class GetEmployeesListSteps
{
    private readonly AppContext _context;

    private List<EmployeeModel> _results;

    public GetEmployeesListSteps(AppContext context)
    {
        _context = context;
        _results = new List<EmployeeModel>();
    }

    [ When(@"I request a list of employees") ]
    public void WhenIRequestAListOfEmployees()
    {
        var query = _context.Container
                            .GetService<IGetEmployeesListQuery>();

        _results = query.Execute();
    }

    [ Then(@"the following employees should be returned:") ]
    public void ThenTheFollowingEmployeesShouldBeReturned(Table table)
    {
        List<EmployeeModel> models = table.CreateSet<EmployeeModel>().ToList();

        for (int i = 0; i < models.Count; i++)
        {
            EmployeeModel model = models[i];

            EmployeeModel result = _results[i];

            Assert.That(result.Id,
                        Is.EqualTo(model.Id));

            Assert.That(result.Name,
                        Is.EqualTo(model.Name));
        }
    }
}
