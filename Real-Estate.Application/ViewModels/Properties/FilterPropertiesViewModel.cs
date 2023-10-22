using Real_Estate.Application.ViewModels.Improvements;
using Real_Estate.Application.ViewModels.TypeOfProperties;
using Real_Estate.Application.ViewModels.TypeOfSales;


namespace Real_Estate.Application.ViewModels.Properties
{
    public class FilterPropertiesViewModel
    {
        public string? Code { get; set; }
        public List<int>? Ids { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
    }
}
