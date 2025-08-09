using System.ComponentModel.DataAnnotations;

namespace OrganicForm.Models
{
    public class Products
    {
        public int Id { get; set; }

        [Required, StringLength(200)]
        public string ProductName { get; set; }=string.Empty;

    }
}
