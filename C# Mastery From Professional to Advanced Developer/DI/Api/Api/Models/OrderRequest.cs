namespace Api.Models
{
    public class OrderRequest : IOrder
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public string ProductName { get; set; }
        public int Qty { get; set; }
    }
}
