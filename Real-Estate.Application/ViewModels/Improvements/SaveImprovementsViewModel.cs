using System.ComponentModel.DataAnnotations;
namespace Real_Estate.Application.ViewModels.Improvements
{
    public class SaveImprovementsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La descripcion es requerida")]
        public string Description { get; set; }
    }
}
