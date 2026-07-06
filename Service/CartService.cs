using Ecommerce_Backend.Dto;
using Ecommerce_Backend.Exceptions;
using Ecommerce_Backend.Model;
using Ecommerce_Backend.Repository;
using Ecommerce_Backend.Service;

namespace Ecommerce_Backend
{
    public class CartService(ICartRepository repoCart, ICartItemRepository repoCartItem,IProductRepository repoPrd) : ICartService
    {

        public async Task AddToCart(CartReqDto dto, int userId)
        {
            System.Console.WriteLine("cart service call started");
            var cart = await repoCart.GetCartByUserId(userId);
            System.Console.WriteLine("cart fetched successfully");
            if (cart == null)
            {
                System.Console.WriteLine("cart is null");
                cart = new Cart { UserId = userId };
                await repoCart.Add(cart);
                await repoCart.SaveChange();
            }
            //if cart is present fetch the cartItem
            System.Console.WriteLine("cart is not null=" + cart);
            var product = await repoPrd.GetById(dto.ProductId);
            if(product==null){throw new NotFoundException($"resourse with {dto.ProductId} was not present");}
            var cartItem = await repoCartItem.GetCartItemAsync(cart.Id, dto.ProductId);
            if (cartItem != null)
            {
                System.Console.WriteLine("cartItems is null");
                //update the quantity then save
                cartItem.Quantity += dto.Quantity;
            }
            else
            {
                cartItem = new CartItem
                {
                    CartId = cart.Id,
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity
                };
                System.Console.WriteLine("cartitem is updated" + cartItem);
                await repoCartItem.Add(cartItem);
            }
            await repoCartItem.SaveChange();
        }
        public async Task<CartResDto> GetCart(int userId)
        {
            var cart = await repoCart.GetCartWithItemsByUserId(userId) ?? throw new NotFoundException("cart was not found please add items into the cart"); ;

            var items = cart.CartItems.Select(ci => new CartItemDto
            {
                ProductId = ci.ProductId,
                ProductName = ci.Product.Name,
                Quantity = ci.Quantity,
                UnitPrice = ci.Product.Price,
                SubTotal = ci.Product.Price * ci.Quantity

            }
            ).ToList();
            var res = new CartResDto
            {
                CartId = cart.Id,
                Items = items,
                Total = items.Sum(i => i.SubTotal)
            };
            return res;
        }
        public async Task UpdateCart(CartUpdateReqDto dto, int userId)
        {
            var cart = await repoCart.GetCartByUserId(userId) ?? throw new NotFoundException("cart is not present please add items to cart");
            var cartItem = await repoCartItem.GetCartItemAsync(cart.Id, dto.ProductId) ?? throw new NotFoundException("cart  items is not present");
            if (dto.Quantity <= 0)
            {
                repoCartItem.Delete(cartItem);
                await repoCartItem.SaveChange();
                return;
            }
            cartItem.Quantity = dto.Quantity;
            await repoCartItem.SaveChange();

        }
        public async Task RemoveCartItem(int userId, int prdId)
        {
            var cart = await repoCart.GetCartByUserId(userId) ?? throw new NotFoundException("cart is not present please add items to cart");
            var cartItem = await repoCartItem.GetCartItemAsync(cart.Id, prdId) ?? throw new NotFoundException("cart  items is not present");
            repoCartItem.Delete(cartItem);
            await repoCartItem.SaveChange();
        }
    }

}
