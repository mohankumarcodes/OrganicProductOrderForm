using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrganicForm.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; } = null!;

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Products Products { get; set; }=null!;

        [Required,Range(0,100000)]
        [Column(TypeName="decimal(18,2)")]
        public decimal Quantity { get; set; }

        [Required]
        public int Unit { get; set; }

        [Required, Range(0, 100000)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

    }
}
