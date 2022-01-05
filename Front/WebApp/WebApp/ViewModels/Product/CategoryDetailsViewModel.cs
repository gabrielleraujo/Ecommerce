using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class CategoryDetailsViewModel
    {
        [Required(ErrorMessage = "{0} não informado.")]
        public int Id { get; set; }

        public string CategoryText { get; private set; }
    }
}