namespace Core.Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }
        public string Department { get; set; }
    }
}