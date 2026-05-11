namespace Api.Models
{
    public interface IOrder
    {
        Guid Id { get; set; }
        string UserEmail { get; set; }
        string ProductName { get; set; }

        int Qty { get; set; }
    }
}
