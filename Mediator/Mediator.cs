using System;

namespace PatternsCsharp.Mediator.Conceptual
{
    public interface IMediator
    {
        void Notify(object sender, string ev);
    }

    class ConcreteMediator : IMediator
    {
        private Component1 _component1;
        private Component2 _conponent2;

        public ConcreteMediator(Component1 component1, Component2 component2)
        {
            this._component1 = component1;
            this._component1.SetMediator(this);
            this._conponent2 = component2;
            this._conponent2.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            if (ev == "A")
            {
                Console.WriteLine("Mediator reacts on A:");
                this._conponent2.DoC();
            }
            if (ev == "B")
            {
                Console.WriteLine("Mediator reacts on B:");
                this._component1.DoB();
                this._conponent2.DoC();
            }
        }
    }

    class BaseComponent
    {
        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }

    class Component1 : BaseComponent
    {
        public void DoA()
        {
            Console.WriteLine("Component1 does A.");
            this._mediator.Notify(this, "A");
        }

        public void DoB()
        {
            Console.WriteLine("Component1 does B.");
            this._mediator.Notify(this, "B");
        }
    }

    class Component2 : BaseComponent
    {
        public void DoC()
        {
            Console.WriteLine("Component2 does C.");
            this._mediator.Notify(this, "C");
        }

        public void DoD()
        {
            Console.WriteLine("Component2 does D.");
            this._mediator.Notify(this, "D");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Component1 component1 = new Component1();
            Component2 component2 = new Component2();
            new ConcreteMediator(component1, component2);

            Console.WriteLine("Client triggers operation A.");
            component1.DoA();

            Console.WriteLine("Client triggers operation D.");
            component2.DoD();
        }
    }
}
