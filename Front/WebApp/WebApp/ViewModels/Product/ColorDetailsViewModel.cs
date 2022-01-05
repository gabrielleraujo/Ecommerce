using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class ColorDetailsViewModel
    {
        [Required(ErrorMessage = "{0} não informado.")]
        public int Id { get; set; }

        public string ColorText { get; private set; }
    }
}