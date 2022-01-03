using System;

namespace PatternsCsharp.Decorator.Conceptual
{
    public abstract class Component
    {
        public abstract string Action();
    }

    class ConcreteComponent: Component
    {
        public override string Action()
        {
            return "Concrete action";
        }
    }

    abstract class Decorator: Component
    {
        protected Component _component;

        public Decorator(Component component)
        {
            this._component = component;
        }

        public void SetComponent(Component component)
        {
            this._component = component;
        }

        public override string Action()
        {
            if (this._component != null)
            {
                return this._component.Action();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    class ConcreteDecoratorA: Decorator
    {
        public ConcreteDecoratorA(Component component): base(component) { }

        public override string Action()
        {
            return $"ConcreteDecoratorA({base.Action()})";
        }
    }

    class ConcreteDecoratorB: Decorator
    {
        public ConcreteDecoratorB(Component component): base(component) { }

        public override string Action()
        {
            return $"ConcreteDecoratorB({base.Action()})";
        }
    }

    public class Client
    {
        public void ClientCode(Component component)
        {
            Console.WriteLine($"RESULT: {component.Action()}");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            var simple = new ConcreteComponent();

            Console.WriteLine("Client: Simple component action:");
            client.ClientCode(simple);
            Console.WriteLine();

            ConcreteDecoratorA decoratorA = new ConcreteDecoratorA(simple);
            ConcreteDecoratorB decoratorB = new ConcreteDecoratorB(decoratorA);

            Console.WriteLine("Client: Now decorated twice:");
            client.ClientCode(decoratorB);
        }
    }
}
