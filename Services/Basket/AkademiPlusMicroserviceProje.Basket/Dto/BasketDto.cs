using System.Collections.Generic;
using System.Linq;

namespace AkademiPlusMicroserviceProje.Basket.Dto
{
    public class BasketDto
    {
        public string UserID { get; set; }
        public string? DiscountCode { get; set; }
        public int? DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }
        public decimal TotalPrice { get => BasketItems.Sum(x => x.ProductPrice * x.Quantity); }
    }
}
