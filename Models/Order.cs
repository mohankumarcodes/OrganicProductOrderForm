using System.ComponentModel.DataAnnotations;

namespace OrganicForm.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }= DateTime.Now;

        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

    }
}
