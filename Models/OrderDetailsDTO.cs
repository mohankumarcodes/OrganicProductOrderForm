namespace OrganicForm.Models
{
    public class OrderDetailsDTO
    {
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public int Unit { get; set; }
        public decimal Price { get; set; }
    }
}
