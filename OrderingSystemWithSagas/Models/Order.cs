namespace OrderingSystemWithSagas.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
    }
}