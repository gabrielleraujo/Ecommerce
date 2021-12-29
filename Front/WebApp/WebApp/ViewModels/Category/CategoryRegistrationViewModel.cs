using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class CategoryRegistrationViewModel
    {
        [Required(ErrorMessage = "{0} não informado.")]
        public string Name { get; set; }
    }
}