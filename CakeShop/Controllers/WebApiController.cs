using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using CakeShop.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    [Produces("application/json")]
    [Microsoft.AspNetCore.Mvc.Route("api")]
    public class DefaultController : ApiController
    {
        private readonly ICakeRepository _cakeRepository;
        private readonly IShoppingCartService _shoppingCart;
        private readonly IOrderRepository _orderRepository;
        public DefaultController(ICakeRepository cakeRepository, IShoppingCartService shoppingCart, IOrderRepository orderRepository)
        {
            _cakeRepository = cakeRepository;
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }

        // POST: http://localhost:[PortNumber]/api/5/1
        // Inputs: Cake Id, Amount of Cake
        // Functionality: Orders X amount of a Cake. Cake type and amount is chosen by user
        [Microsoft.AspNetCore.Mvc.HttpPost("{cakeId}/{qty}", Name = "Post")]
        public async Task Post([Microsoft.AspNetCore.Mvc.FromBody]Order data, string cakeId, string qty)
        { 

            // Simple Error Checking for Cakes that are not currently in the Database. Currently there are 5 cakes.
            // Can improve functionality by checking the database and the most recent max number of cakes
            if (Int32.Parse(cakeId) > 5)
            {
                var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
                {
                    Content = new StringContent("You are out of range of available Cakes.")
                };
                throw new HttpResponseException(message);
            }

            for (int i = 0; i < Int32.Parse(qty); i++)
            {
                Cake cake = await _cakeRepository.GetCakeById(Int32.Parse(cakeId));
                await _shoppingCart.AddToCartAsync(cake);
            }

            // Place Requested Order
            await _orderRepository.CreateOrderAsync(data);

            // Empty Temporary Shopping cart entries 
            await _shoppingCart.ClearCartAsync();
        }
    }
}
