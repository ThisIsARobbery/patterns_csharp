using System;
using System.Collections.Generic;

namespace PatternsCsharp.Builder
{
    public interface ICartBuilder
    {
        void BuildMilk();
        void BuildSousages();
        void BuildBread();
        Cart GetCart();
    }

    public class OnlineCartBuilder: ICartBuilder
    {
        private Cart _cart = new Cart();

        public OnlineCartBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._cart = new Cart();
        }
        public void BuildMilk()
        {
            this._cart.Add("Milk");
        }
        public void BuildSousages()
        {
            this._cart.Add("Sousages");
        }
        public void BuildBread()
        {
            this._cart.Add("Bread");
        }
        public Cart GetCart()
        {
            Cart result = this._cart;
            this.Reset();
            return result;
        }
    }

    public class Cart
    {
        private List<object> _groceries = new List<object>();
        public void Add(string product)
        {
            this._groceries.Add(product);
        }
        public string ListCart()
        {
            string str = string.Empty;

            for (int i = 0; i < _groceries.Count; i++)
            {
                str += this._groceries[i] + ", ";
            }
            str = str.Remove(str.Length - 2);
            return "Products: " + str + "\n";
        }
    }

    public class CartDirector
    {
        private ICartBuilder _builder;
        public ICartBuilder Builder
        {
            set { _builder = value; }
        }
        public void BuildMilkHeavenCart()
        {
            this._builder.BuildMilk();
            this._builder.BuildMilk();
            this._builder.BuildMilk();
        }
        public void BuildFullClip()
        {
            this._builder.BuildMilk();
            this._builder.BuildSousages();
            this._builder.BuildBread();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CartDirector director = new CartDirector();
            ICartBuilder builder = new OnlineCartBuilder();
            director.Builder = builder;

            Console.WriteLine("Milky way:");
            director.BuildMilkHeavenCart();
            Console.WriteLine(builder.GetCart().ListCart());

            Console.WriteLine("Full of groceries:");
            director.BuildFullClip();
            Console.WriteLine(builder.GetCart().ListCart());
        }
    }
}
