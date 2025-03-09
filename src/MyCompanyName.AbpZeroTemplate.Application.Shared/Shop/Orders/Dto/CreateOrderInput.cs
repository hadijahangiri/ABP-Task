using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Shop.Orders.Dto
{
    public class CreateOrderInput
    {
        public List<CreateOrderItemInput> Items { get; set; } = new();
    }

    public class CreateOrderItemInput
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }
}
