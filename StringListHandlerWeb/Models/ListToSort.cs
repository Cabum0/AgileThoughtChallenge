using System.ComponentModel.DataAnnotations;

namespace StringListHandlerWeb.Models
{
    public class ListToSort
    {
        [Required(ErrorMessage = "You should provide a names value.")]
        public string[] Names { get; set; }

        [Required(ErrorMessage = "You should provide a order value.")]
        public int[] Order { get; set; }
    }
}
