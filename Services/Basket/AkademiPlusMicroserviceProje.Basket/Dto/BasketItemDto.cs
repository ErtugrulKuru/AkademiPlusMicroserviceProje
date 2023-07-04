namespace AkademiPlusMicroserviceProje.Basket.Dto
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
