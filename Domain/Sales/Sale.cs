using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Customers;
using CleanArchitecture.Domain.Employees;
using CleanArchitecture.Domain.Products;

namespace CleanArchitecture.Domain.Sales;

public sealed class Sale : IEntity
{
    private int _quantity;

    private decimal _unitPrice;

    public DateTime Date { get; set; }

    public Customer Customer { get; set; }

    public Employee Employee { get; set; }

    public Product Product { get; set; }

    public decimal UnitPrice
    {
        get => _unitPrice;

        set
        {
            _unitPrice = value;

            UpdateTotalPrice();
        }
    }

    public int Quantity
    {
        get => _quantity;

        set
        {
            _quantity = value;

            UpdateTotalPrice();
        }
    }

    public decimal TotalPrice { get; private set; }

    public int Id { get; set; }

    private void UpdateTotalPrice()
    {
        TotalPrice = _unitPrice * _quantity;
    }
}
