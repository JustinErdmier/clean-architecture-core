using NUnit.Framework;

namespace CleanArchitecture.Domain.Employees;

[ TestFixture ]
public sealed class EmployeeTests
{
    [ SetUp ]
    public void SetUp()
    {
        _employee = new Employee();
    }

    private Employee _employee;

    private const int Id = 1;

    private const string Name = "Test";

    [ Test ]
    public void TestSetAndGetId()
    {
        _employee.Id = Id;

        Assert.That(_employee.Id,
                    Is.EqualTo(Id));
    }

    [ Test ]
    public void TestSetAndGetName()
    {
        _employee.Name = Name;

        Assert.That(_employee.Name,
                    Is.EqualTo(Name));
    }
}
