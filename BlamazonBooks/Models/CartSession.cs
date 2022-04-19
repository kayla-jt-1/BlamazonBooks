using BlamazonBooks.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlamazonBooks.Models 
{
    public class CartSession : Basket
    {
        public static Basket GetBasket (IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            CartSession cart = session?.GetJson<CartSession>("Basket") ?? new CartSession();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore] //prevents a property from being serialized or deserialiazed
        public ISession Session { get; set; }

        public override void AddItem(Book book, int qty)
        {
            base.AddItem(book, qty);
            Session.SetJson("Basket", this);
        }
        public override void RemoveItem(Book book)
        {
            base.RemoveItem(book);
            Session.SetJson("Basket", this);
        }
        public override void ClearAll()
        {
            base.ClearAll();
            Session.Remove("Basket");
        }
    }
}
