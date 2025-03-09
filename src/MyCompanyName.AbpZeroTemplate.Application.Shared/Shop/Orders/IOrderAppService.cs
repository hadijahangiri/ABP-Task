using MyCompanyName.AbpZeroTemplate.Shop.Orders.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompanyName.AbpZeroTemplate.Shop.Orders
{
    public interface IOrderAppService
    {
        Task CreateOrder(CreateOrderInput input);
    }
}
