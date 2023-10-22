using Real_Estate.Application.ViewModels.TypeOfSales;
using Real_Estate.Domain.Entities;

namespace Real_Estate.Application.Interfaces.Services
{
    public interface ITypeOfSalesService : IGenericService<SaveTypeOfSalesViewModel, TypeOfSalesViewModel, TypeOfSales>
    {
    }
}
