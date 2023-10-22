using System.ComponentModel.DataAnnotations;

namespace Real_Estate.Application.ViewModels.TypeOfSales
{
    public class SaveTypeOfSalesViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string Description { get; set; }
    }
}
