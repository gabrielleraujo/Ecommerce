using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class SizeDetailsViewModel
    {
        [Required(ErrorMessage = "{0} não informado.")]
        public int Id { get; set; }

        public string SizeText { get; private set; }
    }
}